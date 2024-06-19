namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Helpers;
    using PersonalRecord.Services.Interfaces;

    public partial class SettingsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        private Setting _setting;

        public SettingsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoadSettings();
        }

        private void LoadSettings()
        {
            Setting = SettingsHelper.LoadSettings();
        }

        public Setting Setting
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
        }

        public IEnumerable<Language> Languages
        {
            get => Enum.GetValues(typeof(Language)).Cast<Language>();
        }

        [RelayCommand]
        public async Task SaveAndGoBack()
        {
            SettingsHelper.UpdateSettings(Setting);
            await _navigationService.GoBackAsync();
        }
    }
}