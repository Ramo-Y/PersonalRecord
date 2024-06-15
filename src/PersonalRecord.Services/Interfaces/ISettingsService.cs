namespace PersonalRecord.Services.Interfaces
{
    using PersonalRecord.Infrastructure;

    public interface ISettingsService
    {
        Task<Setting> LoadSettings();

        Task UpdateSettings(Setting setting);
    }
}