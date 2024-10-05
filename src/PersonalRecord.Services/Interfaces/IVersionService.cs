namespace PersonalRecord.Services.Interfaces
{
    public interface IVersionService
    {
        string GetAppVersion();

        string GetInformationalVersion();

        string GetCommitHash();
    }
}