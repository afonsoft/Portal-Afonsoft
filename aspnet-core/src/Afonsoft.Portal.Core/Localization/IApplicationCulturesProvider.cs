using System.Globalization;

namespace Afonsoft.Portal.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}