namespace PersonalRecord.Domain.Helpers
{
    using PersonalRecord.Infrastructure.Constants;

    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            var appDataDirectory = FileSystem.AppDataDirectory;
            var path = Path.Combine(appDataDirectory, EnvironmentConstants.DATABASE_NAME);
            var connectionString = $"Data Source={path}";
            return connectionString;
        }
    }
}