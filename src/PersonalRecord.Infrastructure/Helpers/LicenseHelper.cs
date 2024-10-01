namespace PersonalRecord.Infrastructure.Helpers
{
    using PersonalRecord.Infrastructure.Constants;
    using Syncfusion.Licensing;

    public static class LicenseHelper
    {
        public async static Task RegisterLicenseAsync()
        {
            var stream = await FileSystem.OpenAppPackageFileAsync(EnvironmentConstants.LICENSE_FILENAME);
            var reader = new StreamReader(stream);
            var license = await reader.ReadToEndAsync();
            SyncfusionLicenseProvider.RegisterLicense(license);
        }
    }
}