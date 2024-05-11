namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class SettingsView : ContentPage
    {
        public SettingsView(SettingsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}