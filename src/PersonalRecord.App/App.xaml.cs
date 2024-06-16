using PersonalRecord.Domain.Models;
using Syncfusion.Maui.Themes;

namespace PersonalRecord.App
{
    public partial class App : Application
    {
        public App(PreparationDatabase preparationDatabase)
        {
            InitializeComponent();

            MainThread.BeginInvokeOnMainThread(async () => 
            {
                await preparationDatabase.PreparatePopulation();
            });


            SetTheme();
            Current!.RequestedThemeChanged += (s, a) =>
            {
                SetTheme();
            };

            MainPage = new AppShell();
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
