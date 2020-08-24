// Decompiled with JetBrains decompiler
// Type: Abp.AspNetZeroCore.Licensing.LicenseCheckInfo
// Assembly: Abp.AspNetZeroCore, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C04A4B48-ACC3-437A-A98E-0541F047878B
// Assembly location: C:\Portal-Afonsoft\nuget\abp.aspnetzerocore\2.0.0\lib\netcoreapp3.0\Abp.AspNetZeroCore.dll

using System;

namespace Abp.AspNetZeroCore.Licensing
{
  public class LicenseCheckInfo
  {
    public string LicenseCode { get; set; }

    public string UniqueComputerId { get; set; }

    public string ProjectAssemblyName { get; set; }

    public string LicenseController { get; set; }

    public string ComputerName { get; set; }

    public string ControlCode { get; set; }

    public DateTime DateOfClient { get; set; }
  }
}
