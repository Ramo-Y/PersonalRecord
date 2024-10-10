namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Services.Interfaces;

    public partial class SettingsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        private Setting _setting;

        public SettingsViewModel(
            INavigationService navigationService,
            ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;

            LoadSettings();
        }

        private void LoadSettings()
        {
            Setting = _settingsService.LoadSettings();
        }

        public IEnumerable<Language> Languages
        {
            get => Enum.GetValues(typeof(Language)).Cast<Language>();
        }

        [RelayCommand]
        public async Task SaveAndGoBackAsync()
        {
            _settingsService.UpdateSettings(Setting);
            await _navigationService.GoBackAsync();
        }
    }
}