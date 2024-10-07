namespace PersonalRecord.Services.Interfaces
{
    public interface IVersionService
    {
        string GetAppVersion();

        string GetCopyright();

        string GetInformationalVersion();

        string GetCommitHash();
    }
}