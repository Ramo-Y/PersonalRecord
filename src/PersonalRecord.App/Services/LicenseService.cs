namespace PersonalRecord.App.Services
{
    using PersonalRecord.Infrastructure.Constants;

    public static class LicenseService
    {
        public static string LoadLicense()
        {
            var stream = FileSystem.OpenAppPackageFileAsync(EnvironmentConstants.LICENSE_FILENAME).Result;
            var reader = new StreamReader(stream);
            var license = reader.ReadToEnd();
            return license;
        }
    }
}