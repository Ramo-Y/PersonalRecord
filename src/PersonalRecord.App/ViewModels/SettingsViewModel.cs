namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Services.Interfaces;

    public partial class SettingsViewModel : ObservableObject
    {
        private readonly ISettingsService _settingsService;

        private Setting _setting;

        public SettingsViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;

            LoadSettings();
        }

        private void LoadSettings()
        {
            Setting = _settingsService.LoadSettings().Result;
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
    }
}