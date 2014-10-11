using System;
using System.Configuration;
using System.Collections.Generic;

namespace CJia.PEIS.Tools
{
    /// <summary>
    /// Sosoft配置文件辅助类
    /// </summary> 
    public static class ConfigHelper
    {

        /// <summary>
        /// 判断appStrings配置节是否存在指定配置
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static bool IsExist(string strKey)
        {
            foreach(string key in ConfigurationManager.AppSettings)
            {
                if(key == strKey)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  appStrings配置节获取配置
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetAppStrings(string strKey)
        {
            if(IsExist(strKey))
            {
                return ConfigurationManager.AppSettings[strKey];
            }
            else
            {
                throw new Exception("appStrings配置节没有指定的键值对");
            }
        }

        /// <summary>
        /// appStrings配置节修改配置
        /// </summary>
        /// <param name="newKey"></param>
        /// <param name="newValue"></param>
        public static void UpdateAppStrings(string newKey, string newValue)
        {
            if(IsExist(newKey))
            {
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove(newKey);
                config.AppSettings.Settings.Add(newKey, newValue);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                throw new Exception("appStrings配置节没有指定的键值对");
            }
        }

        /// <summary>
        /// appStrings配置节增加配置
        /// </summary>
        /// <param name="newKey"></param>
        /// <param name="newValue"></param>
        public static void AddAppStrings(string newKey, string newValue)
        {
            if(IsExist(newKey))
            {
                throw new Exception("appStrings配置节已经有了相应的键值对");
            }
            else
            {
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Add(newKey, newValue);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        /// <summary>
        /// 删除appStrings配置节指定配置
        /// </summary>
        /// <param name="strKey"></param>
        public static void DeleteAppStrings(string strKey)
        {
            if(IsExist(strKey))
            {
                Configuration config =
                        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove(strKey);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                throw new Exception("appStrings配置节中没有该配置");
            }
        }

        /// <summary>
        /// 获取当前应用程序的所有AppStrings配置
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllAppStrings()
        {
            Dictionary<string, string> appStrings = new Dictionary<string, string>();
            foreach(string key in ConfigurationManager.AppSettings)
            {
                appStrings.Add(key, ConfigurationManager.AppSettings[key]);
            }
            return appStrings;
        }
    }
}