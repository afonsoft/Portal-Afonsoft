// Decompiled with JetBrains decompiler
// Type: Abp.AspNetZeroCore.AspNetZeroConfigurationExtensions
// Assembly: Abp.AspNetZeroCore, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C04A4B48-ACC3-437A-A98E-0541F047878B
// Assembly location: C:\Portal-Afonsoft\nuget\abp.aspnetzerocore\2.0.0\lib\netcoreapp3.0\Abp.AspNetZeroCore.dll

using Abp.Configuration.Startup;

namespace Abp.AspNetZeroCore
{
  public static class AspNetZeroConfigurationExtensions
  {
    public static AspNetZeroConfiguration AspNetZero(
      this IModuleConfigurations modules)
    {
      return modules.AbpConfiguration.Get<AspNetZeroConfiguration>();
    }
  }
}
