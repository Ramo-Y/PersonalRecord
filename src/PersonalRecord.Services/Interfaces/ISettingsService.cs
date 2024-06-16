namespace PersonalRecord.Services.Interfaces
{
    using PersonalRecord.Infrastructure;

    public interface ISettingsService
    {
        Setting LoadSettings();

        void UpdateSettings(Setting setting);
    }
}