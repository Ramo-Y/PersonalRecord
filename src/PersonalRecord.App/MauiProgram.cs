namespace PersonalRecord.App
{
    using CommunityToolkit.Maui;
    using epj.RouteGenerator;
    using Microsoft.Extensions.Logging;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.App.Services;
    using PersonalRecord.App.ViewModels;
    using PersonalRecord.App.Views;
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

            // Register ViewModels
            builder.Services.AddSingleton<MainView>();
            builder.Services.AddTransient<PersonalRecordView>();
            builder.Services.AddTransient<SettingsView>();

            // Register ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<PersonalRecordViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            // Register services
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            // Language
            builder.Services.AddLocalization();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}