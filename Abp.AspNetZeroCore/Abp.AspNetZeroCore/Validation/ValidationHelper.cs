// Decompiled with JetBrains decompiler
// Type: Abp.AspNetZeroCore.Validation.ValidationHelper
// Assembly: Abp.AspNetZeroCore, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C04A4B48-ACC3-437A-A98E-0541F047878B
// Assembly location: C:\Portal-Afonsoft\nuget\abp.aspnetzerocore\2.0.0\lib\netcoreapp3.0\Abp.AspNetZeroCore.dll

using Abp.Extensions;
using System.Text.RegularExpressions;

namespace Abp.AspNetZeroCore.Validation
{
  public static class ValidationHelper
  {
    public const string EmailRegex = "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";

    public static bool IsEmail(string value)
    {
      return !value.IsNullOrEmpty() && new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").IsMatch(value);
    }
  }
}
