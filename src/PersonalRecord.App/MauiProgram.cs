namespace PersonalRecord.App
{
    using CommunityToolkit.Maui;
    using epj.RouteGenerator;
    using Microsoft.Extensions.Logging;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.App.Services;
    using UraniumUI;

    [AutoRoutes("View")]
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseUraniumUI()
                .UseUraniumUIMaterial();


            // Register services
            builder.Services.AddSingleton<INavigationService, NavigationService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}