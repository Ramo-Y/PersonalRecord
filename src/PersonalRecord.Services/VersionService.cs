namespace PersonalRecord.Services
{
    using System.Reflection;
    using PersonalRecord.Services.Interfaces;

    public class VersionService : IVersionService
    {
        private const int START_INDEX = 0;
        private const int OFFSET = 1;

        public string GetAppVersion()
        {
            var assembly = GetType().Assembly;
            var assemblyVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            var versionString = assemblyVersion!.Version;
            var version = $"V{versionString}";
            return version;
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