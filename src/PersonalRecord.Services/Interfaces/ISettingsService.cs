namespace PersonalRecord.Services.Interfaces
{
    using PersonalRecord.Infrastructure;

    public interface ISettingsService
    {
        Task<Setting> LoadSettingsAsync();

        Task UpdateSettingsAsync(Setting setting);
    }
}