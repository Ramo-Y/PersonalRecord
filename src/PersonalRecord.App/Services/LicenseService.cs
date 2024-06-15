namespace PersonalRecord.App.Services
{
    using PersonalRecord.Infrastructure.Constants;
    using Syncfusion.Licensing;

    public static class LicenseService
    {
        public static void RegisterLicense()
        {
            var stream = FileSystem.OpenAppPackageFileAsync(EnvironmentConstants.LICENSE_FILENAME).Result;
            var reader = new StreamReader(stream);
            var license = reader.ReadToEnd();
            SyncfusionLicenseProvider.RegisterLicense(license);
        }
    }
}