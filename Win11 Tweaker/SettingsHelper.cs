using System;
using System.IO;
using IniParser;
using IniParser.Model;

namespace Win11_Tweaker
{



    public static class SettingsHelper
    {
        private static string configPath = Path.Combine(AppContext.BaseDirectory, "settings.ini");

        public static bool LoadToggleState(string key)
        {
            if (!File.Exists(configPath))
                return false; // Default to 'false' if no config file exists

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(configPath);

            // ✅ Ensure "Toggles" section exists before accessing it
            if (!data.Sections.ContainsSection("Toggles") || !data["Toggles"].ContainsKey(key))
                return false;

            return data["Toggles"][key] == "1";
        }


        public static void SaveToggleState(string key, bool isOn)
        {
            var parser = new FileIniDataParser();
            IniData data = File.Exists(configPath) ? parser.ReadFile(configPath) : new IniData();

            // ✅ Ensure "Toggles" section exists
            if (!data.Sections.ContainsSection("Toggles"))
                data.Sections.AddSection("Toggles");

            data["Toggles"][key] = isOn ? "1" : "0";
            parser.WriteFile(configPath, data);
        }
    }

}
