using System;
using System.Configuration;
using System.Diagnostics;

namespace Arduistats
{
    internal class ACConfigManager
    {
        public void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Debug.WriteLine("ReadSetting() try ok : " + result);
            }
            catch (ConfigurationErrorsException)
            {
                Debug.WriteLine("Error reading app settings");
            }
        }
        public static string getSettings(string key)
        {
            string result = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
                Debug.WriteLine("ReadSetting() try ok : " + result);
            }
            catch (ConfigurationErrorsException)
            {
                Debug.WriteLine("Error reading app settings");
            }
            return result;
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                    Debug.WriteLine("Wrote Added");
                }
                else
                {
                    settings[key].Value = value;
                    Debug.WriteLine("Wrote Updated ?");
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
        public static void ClearValue(string key)
        {

        }
        public static bool CheckIfValueExists()
        {
            bool domainExists = false;
            
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings["userdomain"] ?? "Not Found";
                if (result != "none")
                    {
                        domainExists = true;
                        Debug.WriteLine("DomainExists()  : " + result);
                    }
                   // Debug.WriteLine("ReadSetting() try ok : " + result);
                else
                {
                    domainExists = false;
                }
            }
            catch (ConfigurationErrorsException)
            {
                Debug.WriteLine("Error reading app settings");
            }
            
            return domainExists;
        }


    }
}
