using System.Configuration;

namespace TDD_Practices.Utils
{
  public static class AppSettingsManager
  {
    public static string GetStringOrDefault(string appSettingName, string defaultValue)
    {
      string appSetting = ConfigurationManager.AppSettings[appSettingName];
      return !string.IsNullOrEmpty(appSetting) ? appSetting : defaultValue;
    }

    public static int GetIntegerOrDefault(string appSettingName, int defaultValue)
    {
      int result;
      return int.TryParse(ConfigurationManager.AppSettings[appSettingName], out result)
        ? result : defaultValue;
    }

    public static bool GetBooleanOrDefault(string appSettingName, bool defaultValue)
    {
      bool result;
      return bool.TryParse(ConfigurationManager.AppSettings[appSettingName], out result) 
        ? result : defaultValue;
    }
  }
}