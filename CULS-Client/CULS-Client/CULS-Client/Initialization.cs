using IniParser;
using IniParser.Model;
using System;

namespace CULS_SERVER
{
    class Initialization
    {
        private const string CONFIG_FILE_NAME = "config.ini";
        private static IniData configData = null;

        public static string ReadConfigurationFile(String section, String key)
        {
            OpenConfigurationFile();
            string value = configData[section][key];

            return value;
        }

        public static void WriteConfigurationFile(String section, String key, String newValue)
        {
            OpenConfigurationFile();
            var parser = new FileIniDataParser();

            configData[section][key] = newValue;
            parser.WriteFile(CONFIG_FILE_NAME, configData);
        }

        private static void OpenConfigurationFile()
        {
            var parser = new FileIniDataParser();

            try
            {
                configData = parser.ReadFile(CONFIG_FILE_NAME);
            }
            catch (Exception e)
            {
                //config file is missing, create new file here

                //read again
                configData = parser.ReadFile(CONFIG_FILE_NAME);
            }
        }
    }
}
