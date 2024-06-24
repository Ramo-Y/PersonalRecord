using CommunityToolkit.Mvvm.Messaging;
using PersonalRecord.Domain.Models;
using PersonalRecord.Services.Events;
using PersonalRecord.Services.Interfaces;
using Syncfusion.Maui.Themes;
using System.Globalization;

namespace PersonalRecord.App
{
    public partial class App : Application
    {
        private readonly ISettingsService _settingsService;
        
        private delegate void Callback();

        public App(PreparationDatabase preparationDatabase, ISettingsService settingsService)
        {
            InitializeComponent();

            _settingsService = settingsService;

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await preparationDatabase.PreparatePopulation();
            });

            // Language
            SetCulture();
            WeakReferenceMessenger.Default.Register<LanguageChangedMessage>(this, (m, e) =>
            {
                RestartAppWithAction(SetCulture);
            });

            // Theme
            SetTheme();
            Current!.RequestedThemeChanged += (s, a) =>
            {
                RestartAppWithAction(SetTheme);
            };

            MainPage = new AppShell();
        }

        private void RestartAppWithAction(Callback callback)
        {
            (App.Current as App)!.MainPage!.Dispatcher.Dispatch(() =>
            {
                callback();
                (App.Current as App)!.MainPage = new AppShell();
            });
        }

        private void SetCulture()
        {
            var culture = "en-US";
            var settings = _settingsService.LoadSettings();

            culture = settings.Language switch
            {
                Infrastructure.Language.English => "en-US",
                Infrastructure.Language.German => "de-DE",
                _ => "en-US",
            };

            var cultureInfo = new CultureInfo(culture, false);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        private void SetTheme()
        {
            var plattformTheme = Current!.PlatformAppTheme;
            ICollection<ResourceDictionary> mergedDictionaries = Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                var theme = mergedDictionaries.OfType<SyncfusionThemeResourceDictionary>().FirstOrDefault();
                if (theme != null)
                {
                    if (plattformTheme == AppTheme.Dark)
                    {
                        theme.VisualTheme = SfVisuals.MaterialDark;
                    }
                    else
                    {
                        theme.VisualTheme = SfVisuals.MaterialLight;
                    }
                }
            }
        }
    }
}