﻿namespace PersonalRecord.Services
{
    using Newtonsoft.Json;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Services.Interfaces;

    public class SettingsService : ISettingsService
    {
        private static string _jsonFilePath;

        public SettingsService()
        {
            var appDataDirectory = FileSystem.AppDataDirectory;
            _jsonFilePath = Path.Combine(appDataDirectory, EnvironmentConstants.SETTINGS_FILE_NAME);
        }

        public Setting LoadSettings()
        {
            Setting setting;
            var exists = File.Exists(_jsonFilePath);
            if (!exists)
            {
                setting = CreateDefaultSettings();
                SerializeSettings(setting);
                return setting;
            }

            var settingJsonText = File.ReadAllText(_jsonFilePath);
            setting = JsonConvert.DeserializeObject<Setting>(settingJsonText);

            return setting;
        }

        public void UpdateSettings(Setting setting)
        {
            SerializeSettings(setting);
        }

        private void SerializeSettings(Setting setting)
        {
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            using (var sw = new StreamWriter(_jsonFilePath))
            using (var writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, setting);
            }
        }

        private Setting CreateDefaultSettings()
        {
            var setting = new Setting()
            {
                DateFormat = DefaultConstants.DEFAULT_DATE_FORMAT,
                Unit = DefaultConstants.DEFAULT_UNIT,
                UnitFormat = DefaultConstants.DEFAULT_UNIT_FORMAT,
                Language = Language.English
            };

            return setting;
        }
    }
}