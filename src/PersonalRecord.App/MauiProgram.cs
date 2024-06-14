namespace PersonalRecord.App
{
    using CommunityToolkit.Maui;
    using epj.RouteGenerator;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.App.Services;
    using PersonalRecord.App.ViewModels;
    using PersonalRecord.App.Views;
    using PersonalRecord.Domain.Helpers;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Domain.Repositories;
    using Syncfusion.Maui.Core.Hosting;

    [AutoRoutes("View")]
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var license = LicenseService.LoadLicenseAsync();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(license);

            // Register ViewModels
            builder.Services.AddSingleton<MainView>();
            builder.Services.AddTransient<MovementRecordDetailView>();
            builder.Services.AddTransient<MovementRecordsView>();
            builder.Services.AddTransient<MovementsView>();
            builder.Services.AddTransient<SettingsView>();

            // Register ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<MovementRecordDetailViewModel>();
            builder.Services.AddTransient<MovementRecordsViewModel>();
            builder.Services.AddTransient<MovementsViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            // Register services
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            // DB Context
            builder.Services.AddDbContext<PersonalRecordContext>(opt => opt.UseSqlite(DatabaseHelper.GetConnectionString()));
            builder.Services.AddTransient<PreparationDatabase>();

            // Register repositories
            builder.Services.AddSingleton<IMovementRepository, MovementRepository>();
            builder.Services.AddSingleton<IMovementRecordRepository, MovementRecordRepository>();

            // Language
            builder.Services.AddLocalization();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            return app;
        }
    }
}