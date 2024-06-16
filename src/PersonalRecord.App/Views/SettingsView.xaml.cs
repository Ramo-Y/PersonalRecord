namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;
    using Syncfusion.Maui.Buttons;
    using Syncfusion.Maui.Themes;

    public partial class SettingsView : ContentPage
    {
        public SettingsView(SettingsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        private async void SfSwitch_StateChanged(object sender, SwitchStateChangedEventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                var theme = mergedDictionaries.OfType<SyncfusionThemeResourceDictionary>().FirstOrDefault();
                if (theme != null)
                {
                    if (e.NewValue == true)
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