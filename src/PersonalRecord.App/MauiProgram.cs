namespace PersonalRecord.App
{
    using CommunityToolkit.Maui;
    using epj.RouteGenerator;
    using MetroLog.MicrosoftExtensions;
    using MetroLog.Operators;
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

            LicenseHelper.RegisterLicense();
            
            // Register ViewModels
            builder.Services.AddSingleton<MainView>();
            builder.Services.AddTransient<MovementRecordAllView>();
            builder.Services.AddTransient<MovementRecordDetailView>();
            builder.Services.AddTransient<MovementRecordMaxesView>();
            builder.Services.AddTransient<MovementsView>();
            builder.Services.AddTransient<SettingsView>();

            // Register ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<MovementRecordAllViewModel>();
            builder.Services.AddTransient<MovementRecordDetailViewModel>();
            builder.Services.AddTransient<MovementRecordMaxesViewModel>();
            builder.Services.AddTransient<MovementsViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            // Register services
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();

            // DB Context
            builder.Services.AddDbContext<PersonalRecordContext>(opt => opt.UseSqlite(DatabaseHelper.GetConnectionString()));
            builder.Services.AddTransient<PreparationDatabase>();

            // Register repositories
            builder.Services.AddSingleton<IMovementRepository, MovementRepository>();
            builder.Services.AddSingleton<IMovementRecordRepository, MovementRecordRepository>();

            // Language
            builder.Services.AddLocalization();

            builder.Logging
                .AddTraceLogger(
                    options =>
                    {
                        options.MinLevel = LogLevel.Trace;
                        options.MaxLevel = LogLevel.Critical;
                    }) // Will write to the Debug Output
                .AddInMemoryLogger(
                    options =>
                    {
                        options.MaxLines = 1024;
                        options.MinLevel = LogLevel.Debug;
                        options.MaxLevel = LogLevel.Critical;
                    })
                .AddStreamingFileLogger(
                    options =>
                    {
                        options.RetainDays = 2;
                        options.FolderPath = Path.Combine(
                            FileSystem.AppDataDirectory,
                            "MetroLogs");
                    });

            builder.Services.AddSingleton(LogOperatorRetriever.Instance);
#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            return app;
        }
    }
}