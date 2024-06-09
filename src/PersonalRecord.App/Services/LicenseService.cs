namespace PersonalRecord.App.Services
{
    using PersonalRecord.Infrastructure.Constants;

    public static class LicenseService
    {
        public static string LoadLicenseAsync()
        {
            // TODO: Load from somewhere else and make non static
            var currentDirectory = Directory.GetCurrentDirectory();
            var licenseFilePath = Path.Combine(currentDirectory, EnvironmentConstants.LICENSE_FILENAME);
            var license = File.ReadAllText(licenseFilePath);
            return license;
        }
    }
}