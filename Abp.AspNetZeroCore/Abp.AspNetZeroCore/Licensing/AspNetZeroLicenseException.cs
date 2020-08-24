// Decompiled with JetBrains decompiler
// Type: Abp.AspNetZeroCore.Licensing.AspNetZeroLicenseException
// Assembly: Abp.AspNetZeroCore, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C04A4B48-ACC3-437A-A98E-0541F047878B
// Assembly location: C:\Portal-Afonsoft\nuget\abp.aspnetzerocore\2.0.0\lib\netcoreapp3.0\Abp.AspNetZeroCore.dll

using System;

namespace Abp.AspNetZeroCore.Licensing
{
  public class AspNetZeroLicenseException : Exception
  {
    public AspNetZeroLicenseException()
      : base("AspNet Zero License Check Failed. Please contact to info@aspnetzero.com if you are using a licensed version!")
    {
    }

    public AspNetZeroLicenseException(string message)
      : base(message)
    {
    }
  }
}
