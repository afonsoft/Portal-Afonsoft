// Decompiled with JetBrains decompiler
// Type: Abp.AspNetZeroCore.Licensing.AspNetZeroLicenseChecker
// Assembly: Abp.AspNetZeroCore, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C04A4B48-ACC3-437A-A98E-0541F047878B
// Assembly location: C:\Portal-Afonsoft\nuget\abp.aspnetzerocore\2.0.0\lib\netcoreapp3.0\Abp.AspNetZeroCore.dll

using Abp.Dependency;
using Abp.Json;
using Abp.Threading;
using Abp.Web.Models;
using Abp.Zero.Configuration;
using Castle.Core.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Abp.AspNetZeroCore.Licensing
{
  public sealed class AspNetZeroLicenseChecker : AspNetZeroBaseLicenseChecker, ISingletonDependency
  {
    private string _licenseCheckFilePath;
    private string _uniqueComputerId;

    public ILogger Logger { get; set; }

    public AspNetZeroLicenseChecker(
      AspNetZeroConfiguration configuration = null,
      IAbpZeroConfig abpZeroConfig = null,
      string configFilePath = "")
      : base(configuration, abpZeroConfig, configFilePath)
    {
      this.Logger = (ILogger) NullLogger.Instance;
    }

    public void Check()
    {
      if (this.IsThereAReasonToNotCheck())
        return;
      Task.Run((Func<Task>) (async () =>
      {
        try
        {
          await this.CheckInternal();
        }
        catch (AspNetZeroLicenseException ex)
        {
          Console.WriteLine(ex.Message);
          this.Logger.Fatal(ex.Message, (Exception) ex);
          Environment.Exit(-42);
          throw;
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          this.Logger.Warn(ex.Message, ex);
        }
      }));
    }

    public void CheckSync()
    {
      try
      {
        AsyncHelper.RunSync(new Func<Task>(this.CheckInternal));
      }
      catch (AspNetZeroLicenseException ex)
      {
        Console.WriteLine(ex.Message);
        Environment.Exit(-42);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private async Task CheckInternal()
    {
      AspNetZeroLicenseChecker zeroLicenseChecker = this;
      try
      {
        zeroLicenseChecker._uniqueComputerId = AspNetZeroLicenseChecker.GetUniqueComputerId();
        zeroLicenseChecker._licenseCheckFilePath = Path.Combine(Path.GetTempPath(), zeroLicenseChecker.GetHashedValue(zeroLicenseChecker.GetLicenseCode()) + ".tmp");
        zeroLicenseChecker.Logger.Debug(zeroLicenseChecker._licenseCheckFilePath);
      }
      catch
      {
        return;
      }
      try
      {
        if (!zeroLicenseChecker.IsProjectNameValid())
          throw new AspNetZeroLicenseException("Failed to validate project name. Should not rename a project downloaded from aspnetzero.com. You can contact to info@aspnetzero.com if you are using a licensed product.");
        if (zeroLicenseChecker.CheckedBefore())
          return;
      }
      catch (Exception ex)
      {
        zeroLicenseChecker.Logger.Fatal("Failed to validate project name. Should not rename a project downloaded from aspnetzero.com. You can contact to info@aspnetzero.com if you are using a licensed product." + Environment.NewLine + ex.Message, ex);
        Environment.Exit(-42);
      }
      await zeroLicenseChecker.ValidateLicenseOnServer();
    }

    private bool CheckedBefore()
    {
      if (!File.Exists(this._licenseCheckFilePath))
        return false;
      string licenseCheckDate = this.GetLastLicenseCheckDate();
      if (this.GetHashedValue(AspNetZeroLicenseChecker.GetTodayAsString()) == licenseCheckDate || this.GetHashedValue(AspNetZeroLicenseChecker.GetLicenseExpiredString()) == licenseCheckDate)
        return true;
      File.Delete(this._licenseCheckFilePath);
      return false;
    }

    private bool IsProjectNameValid()
    {
      return this.CompareProjectName(this.GetHashedProjectName());
    }

    private string GetHashedProjectName()
    {
      return this.GetLicenseCode().Substring(this.GetLicenseCode().Length - 32, 32);
    }

    private async Task ValidateLicenseOnServer()
    {
      LicenseValidationResult validationResult = await this.ValidateLicense(this.GetLicenseCodeWithoutProjectNameHash());
      if (!validationResult.Success)
        throw new AspNetZeroLicenseException();
      if (validationResult.LastRequest)
        this.MarkAsLastRequest();
      else
        this.UpdateLastLicenseCheckDate();
    }

    private string GetLicenseCodeWithoutProjectNameHash()
    {
      return this.GetLicenseCode().Substring(0, this.GetLicenseCode().Length - 32);
    }

    private async Task<LicenseValidationResult> ValidateLicense(
      string licenseCode)
    {
      AspNetZeroLicenseChecker zeroLicenseChecker = this;
      LicenseValidationResult result;
      using (HttpClient httpClient = new HttpClient())
      {
        httpClient.BaseAddress = new Uri("https://www.aspnetzero.com/");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        LicenseCheckInfo licenseInfo = new LicenseCheckInfo()
        {
          LicenseCode = licenseCode,
          UniqueComputerId = zeroLicenseChecker._uniqueComputerId,
          ComputerName = AspNetZeroLicenseChecker.GetComputerName(),
          ControlCode = Guid.NewGuid().ToString(),
          DateOfClient = DateTime.Now,
          ProjectAssemblyName = zeroLicenseChecker.GetAssemblyName(),
          LicenseController = zeroLicenseChecker.GetLicenseController()
        };
        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("LicenseManagement/CheckLicense", (HttpContent) new StringContent(licenseInfo.ToJsonString(false, false), Encoding.UTF8, "application/json"));
        if (!httpResponseMessage.IsSuccessStatusCode)
          throw new AbpException("Failed on license check");
        AjaxResponse<LicenseValidationResult> ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse<LicenseValidationResult>>(await httpResponseMessage.Content.ReadAsStringAsync());
        if (ajaxResponse.Success && ajaxResponse.Result != null)
        {
          if (zeroLicenseChecker.GetHashedValue(licenseInfo.ControlCode) != ajaxResponse.Result.ControlCode)
            throw new AspNetZeroLicenseException("Failed on license check");
          result = ajaxResponse.Result;
          licenseInfo = (LicenseCheckInfo) null;
        }
        else
        {
          ErrorInfo error = ajaxResponse.Error;
          throw new AbpException(error == null || error.Message == null ? "Failed on license check" : error.Message);
        }
      }
      return result;
    }

    private void UpdateLastLicenseCheckDate()
    {
      File.WriteAllText(this._licenseCheckFilePath, this.GetHashedValue(AspNetZeroLicenseChecker.GetTodayAsString()));
    }

    private void MarkAsLastRequest()
    {
      File.WriteAllText(this._licenseCheckFilePath, this.GetHashedValue(AspNetZeroLicenseChecker.GetLicenseExpiredString()));
    }

    private string GetLastLicenseCheckDate()
    {
      return File.ReadAllText(this._licenseCheckFilePath);
    }

    private static string GetUniqueComputerId()
    {
      return ((IEnumerable<NetworkInterface>) NetworkInterface.GetAllNetworkInterfaces()).Where<NetworkInterface>((Func<NetworkInterface, bool>) (nic => nic.OperationalStatus == OperationalStatus.Up)).Select<NetworkInterface, string>((Func<NetworkInterface, string>) (nic => nic.GetPhysicalAddress().ToString())).FirstOrDefault<string>();
    }

    private static string GetComputerName()
    {
      return Environment.MachineName;
    }

    private static string GetTodayAsString()
    {
      return DateTime.Now.ToString("yyyy-MM-dd");
    }

    private string GetHashedValue(string str)
    {
      using (MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider())
        return AspNetZeroLicenseChecker.EncodeBase64(cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(str + this._uniqueComputerId + this.GetSalt())));
    }

    protected override string GetSalt()
    {
      return AspNetZeroLicenseChecker.StringGeneratorFromInteger(new int[20]
      {
        1040716,
        800845,
        530130,
        1070016,
        1150778,
        561680,
        610543,
        1100661,
        850465,
        701962,
        720252,
        450500,
        1041016,
        580023,
        1060241,
        670061,
        1190528,
        580670,
        620222,
        1070077
      });
    }

    private static string GetLicenseExpiredString()
    {
      return AspNetZeroLicenseChecker.StringGeneratorFromInteger(new int[29]
      {
        1400382,
        1103131,
        973808,
        360813,
        1240081,
        1210727,
        1092451,
        1070315,
        1281862,
        1270461,
        400917,
        1310564,
        1760086,
        1220024,
        1471866,
        1142506,
        1020320,
        622427,
        1591867,
        630063,
        1160906,
        320602,
        1101332,
        1240054,
        1140016,
        480081,
        1160031,
        1260050,
        1540058
      });
    }

    private static string StringGeneratorFromInteger(int[] letters)
    {
      string str = "";
      char[] chArray = new char[letters.Length];
      int[] numArray = new int[letters.Length];
      int index1 = 0;
      foreach (int letter in letters)
      {
        for (int index2 = 0; index2 < index1; ++index2)
        {
          --numArray[index2];
          if (numArray[index2] == 0)
          {
            str += chArray[index2].ToString();
            for (int index3 = index2; index3 < index1; ++index3)
              --numArray[index3];
            index2 = -1;
          }
        }
        int num1 = letter / 10000 - letter % 100 / 10 - letter % 10 * (letter % 100 / 10);
        int num2 = letter % 10000 / 100;
        if (num2 != 0)
        {
          chArray[index1] = (char) num1;
          numArray[index1] = num2;
          ++index1;
        }
        str += ((char) num1).ToString();
      }
      for (int index2 = 0; index2 < index1; ++index2)
      {
        --numArray[index2];
        if (numArray[index2] == 0)
        {
          str += chArray[index2].ToString();
          for (int index3 = index2; index3 < index1; ++index3)
            --numArray[index3];
          index2 = -1;
        }
      }
      return str;
    }

    protected override string GetHashedValueWithoutUniqueComputerId(string str)
    {
      using (MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider())
        return AspNetZeroLicenseChecker.EncodeBase64(cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(str + this.GetSalt())));
    }

    private static string EncodeBase64(byte[] ba)
    {
      StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
      foreach (byte num in ba)
        stringBuilder.AppendFormat("{0:x2}", (object) num);
      return stringBuilder.ToString();
    }
  }
}
