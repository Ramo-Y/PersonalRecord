namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Infrastructure.Resources.Languages;
    using PersonalRecord.Services.Interfaces;

    public partial class MainViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IVersionService _versionService;
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        private string _appVersion;

        [ObservableProperty]
        private string _copyright;

        [ObservableProperty]
        private string _technology;

        [ObservableProperty]
        private string _fullVersion;

        [ObservableProperty]
        private string _buildDate;

        [ObservableProperty]
        private bool _popupIsOpen;

        private readonly string _repositoryUrl;

        public MainViewModel(
            INavigationService navigationService,
            IVersionService versionService,
            ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _versionService = versionService;
            _settingsService = settingsService;

            AppVersion = _versionService.GetAppVersion() + " ⓘ";
            _repositoryUrl = _versionService.GetRepositoryUrl();
        }

        [RelayCommand]
        public async Task GoToPersonalRecordMaxesViewAsync()
        {
            await _navigationService.GoToAsync(Routes.PersonalRecordMaxesView);
        }

        [RelayCommand]
        public async Task GoToMovementsViewAsync()
        {
            await _navigationService.GoToAsync(Routes.MovementsView);
        }

        [RelayCommand]
        public async Task GoToPersonalRecordAllViewAsync()
        {
            await _navigationService.GoToAsync(Routes.PersonalRecordAllView);
        }

        [RelayCommand]
        public async Task GoToSettingsViewAsync()
        {
            await _navigationService.GoToAsync(Routes.SettingsView);
        }

        [RelayCommand]
        public async Task GoToImportExportViewAsync()
        {
            await _navigationService.GoToAsync(Routes.ImportExportView);
        }

        [RelayCommand]
        public async Task OpenSupportPageAsync()
        {
            var uri = new Uri(EnvironmentConstants.SPONSOR_URL);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenProjectPageAsync()
        {
            var uri = new Uri(_repositoryUrl);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenProjectIssuesPageAsync()
        {
            var uri = new Uri($"{_repositoryUrl}/issues");
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenCommitOnRepositoryAsync()
        {
            var commitHash = _versionService.GetCommitHash();
            var commitUrl = $"{_repositoryUrl}/commit/{commitHash}";
            var uri = new Uri(commitUrl);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenPrivacyPolicyAsync()
        {
            var privacyPolicyUrl = $"{_repositoryUrl}/{EnvironmentConstants.PRIVACY_POLICY_URL_SUFFIX}";
            var uri = new Uri(privacyPolicyUrl);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task ShareThisAppAsync()
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = AppResources.ShareAppText,
                Uri = EnvironmentConstants.PLAY_STORE_URL
            });
        }

        [RelayCommand]
        public void ShowDetailInformation()
        {
            Copyright = _versionService.GetCopyright();
            Technology = AppResources.DevelopedWithDotNetMaui;
            var informationalVersion = _versionService.GetInformationalVersion();
            FullVersion = $"{AppResources.FullVersion}: {informationalVersion}";

            var settings = _settingsService.GetSettings();
            var buildDate = _versionService.GetBuildDate();
            BuildDate = $"{AppResources.BuildDate}: {buildDate.ToString(settings.DateFormat)}";

            PopupIsOpen = true;
        }

        [RelayCommand]
        public async Task RateThisAppAsync()
        {
            var playStoreUrl = $"{EnvironmentConstants.PLAY_STORE_URL}";
            var uri = new Uri(playStoreUrl);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }
    }
}