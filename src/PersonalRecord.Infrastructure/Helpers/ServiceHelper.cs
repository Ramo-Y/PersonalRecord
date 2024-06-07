namespace PersonalRecord.Infrastructure.Helpers
{
    public static class ServiceHelper
    {
        public static TService GetService<TService>() => Current.GetService<TService>();

        public static IServiceProvider Current
        {
            get
            {
                return IPlatformApplication.Current.Services;
            }
        }
    }
}