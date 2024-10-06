namespace PersonalRecord.Services.UnitTests
{
    using PersonalRecord.Services.Interfaces;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IVersionService, VersionService>();
        }
    }
}