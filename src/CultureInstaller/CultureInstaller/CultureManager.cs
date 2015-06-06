using CultureInstaller.Exceptions;
using System.Globalization;

namespace CultureInstaller
{
    public static class CultureManager
    {
        public static void Install(string cultureName, string basedOnCulture, string basedOnRegion = null)
        {
            try
            {
                CultureInfo.GetCultureInfo(cultureName);

                throw new CultureIsAlreadyInstalled(cultureName);
            }
            catch (CultureNotFoundException)
            {
                var baseCulture = new CultureInfo(basedOnCulture);
                var regionInfo = new RegionInfo(basedOnRegion ?? baseCulture.Name);

                var cultureAndRegionInfoBuilder = new CultureAndRegionInfoBuilder(cultureName, CultureAndRegionModifiers.None);

                cultureAndRegionInfoBuilder.LoadDataFromCultureInfo(baseCulture);
                cultureAndRegionInfoBuilder.LoadDataFromRegionInfo(regionInfo);

                cultureAndRegionInfoBuilder.CultureEnglishName = cultureName;
                cultureAndRegionInfoBuilder.CultureNativeName = cultureName;
                cultureAndRegionInfoBuilder.Parent = baseCulture;

                cultureAndRegionInfoBuilder.Register();
            }
        }

        public static void Uninstall(string cultureName)
        {
            CultureAndRegionInfoBuilder.Unregister(cultureName);
        }
    }
}
