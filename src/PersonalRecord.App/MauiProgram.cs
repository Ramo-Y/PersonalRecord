namespace PersonalRecord.App
{
    using CommunityToolkit.Maui;
    using epj.RouteGenerator;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using PersonalRecord.App.ViewModels;
    using PersonalRecord.App.Views;
    using PersonalRecord.Domain.Helpers;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Domain.Repositories;
    using PersonalRecord.Infrastructure.Helpers;
    using PersonalRecord.Services;
    using PersonalRecord.Services.Interfaces;
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

            Task.Run(LicenseHelper.RegisterLicenseAsync);

            // Register ViewModels
            builder.Services.AddTransient<MainView>();
            builder.Services.AddTransient<PersonalRecordAllView>();
            builder.Services.AddTransient<PersonalRecordDetailView>();
            builder.Services.AddTransient<PersonalRecordMaxesView>();
            builder.Services.AddTransient<MovementsView>();
            builder.Services.AddTransient<SettingsView>();

            // Register ViewModels
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<PersonalRecordAllViewModel>();
            builder.Services.AddTransient<PersonalRecordDetailViewModel>();
            builder.Services.AddTransient<PersonalRecordMaxesViewModel>();
            builder.Services.AddTransient<MovementsViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            // Register services
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();
            builder.Services.AddSingleton<IVersionService, VersionService>();

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