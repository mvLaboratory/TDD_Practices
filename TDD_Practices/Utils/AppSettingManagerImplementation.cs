using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDD_Practices.Utils
{
  public class AppSettingManagerImplementation
  {
    public virtual int GetIntegerOrDefault(string appSettingName, int defaultValue)
    {
      var result =  AppSettingsManager.GetIntegerOrDefault(appSettingName, defaultValue);

      return result;
    }
  }
}