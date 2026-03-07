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
            Setting = _settingsService.GetSettings();
        }

        public IEnumerable<Language> Languages
        {
            get => Enum.GetValues<Language>().Cast<Language>();
        }

        [RelayCommand]
        public async Task SaveAndGoBackAsync()
        {
            var currentSettings = _settingsService.GetSettings();
            var languageChanged = currentSettings.Language != Setting.Language;

            _settingsService.UpdateSettings(Setting);
            if (!languageChanged)
            {
                await _navigationService.GoBackAsync();
            }
        }
    }
}