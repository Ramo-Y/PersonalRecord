namespace PersonalRecord.Services
{
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Services.Interfaces;
    using System.Text.Json;

    public class SettingsService : ISettingsService
    {
        private readonly string _jsonFilePath;

        public SettingsService()
        {
            var appDataDirectory = FileSystem.AppDataDirectory;
            _jsonFilePath = Path.Combine(appDataDirectory, EnvironmentConstants.SETTINGS_FILE_NAME);
        }

        public async Task<Setting> LoadSettings()
        {
            Setting setting;
            var exists = File.Exists(_jsonFilePath);
            if (!exists)
            {
                setting = CreateDefaultSettings();
                await using FileStream createStream = File.Create(_jsonFilePath);
                await JsonSerializer.SerializeAsync(createStream, setting);

                return setting;
            }

            await using FileStream stream = File.OpenRead(_jsonFilePath);
            setting = await JsonSerializer.DeserializeAsync<Setting>(stream);

            return setting;
        }

        public async Task UpdateSettings(Setting setting)
        {
            await using FileStream createStream = File.OpenWrite(_jsonFilePath);
            await JsonSerializer.SerializeAsync(createStream, setting);
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