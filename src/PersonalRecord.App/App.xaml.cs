using PersonalRecord.Domain.Models;
using PersonalRecord.Infrastructure.Helpers;
using PersonalRecord.Services.Interfaces;
using Syncfusion.Maui.Themes;
using System.Globalization;

namespace PersonalRecord.App
{
    public partial class App : Application
    {
        private readonly ISettingsService _settingsService;

        public App(PreparationDatabase preparationDatabase, ISettingsService settingsService)
        {
            InitializeComponent();

            _settingsService = settingsService;

            MainThread.BeginInvokeOnMainThread(async () => 
            {
                await preparationDatabase.PreparatePopulation();
            });
            
            SetCulture();
            SetTheme();
            Current!.RequestedThemeChanged += (s, a) =>
            {
                SetTheme();
            };

            MainPage = new AppShell();
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

            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private static void SetTheme()
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
