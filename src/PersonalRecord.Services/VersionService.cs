namespace PersonalRecord.Services
{
    using System.Diagnostics;
    using System.Reflection;
    using PersonalRecord.Services.Interfaces;

    public class VersionService : IVersionService
    {
        private const int START_INDEX = 0;
        private const int OFFSET = 1;

        public string GetAppVersion()
        {
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version!;
            var version = $"V{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
            return version;
        }

        public string GetCopyright()
        {
            var assemblyFullName = Assembly.GetExecutingAssembly().Location;
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assemblyFullName);
            var legalCopyright = fileVersionInfo.LegalCopyright;
            return legalCopyright;
        }

        public string GetCommitHash()
        {
            var informationalVersion = GetInformationalVersion();
            var index = informationalVersion.IndexOf('+');
            var toDeleteCount = index + OFFSET;
            var commitHash = informationalVersion.Remove(START_INDEX, toDeleteCount);
            return commitHash;
        }

        public string GetInformationalVersion()
        {
            var assembly = GetType().Assembly;
            var informationalVersionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            var informationalVersion = informationalVersionAttribute!.InformationalVersion;
            return informationalVersion;
        }
    }
}