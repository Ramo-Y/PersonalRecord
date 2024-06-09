
namespace PersonalRecord.App.Services
{
    public static class LicenseService
    {
        public static string LoadLicenseAsync()
        {
            // TODO: Load from somewhere else and make non static
            var license = File.ReadAllText("./SyncfusionLicense.txt");
            return license;
        }
    }
}