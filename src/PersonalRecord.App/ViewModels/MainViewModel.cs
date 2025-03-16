namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Infrastructure.Resources.Languages;
    using PersonalRecord.Services.Interfaces;
    using System.Text;

    public partial class MainViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IVersionService _versionService;

        [ObservableProperty]
        private string _appVersion;

        [ObservableProperty]
        private string _copyright;

        [ObservableProperty]
        private string _technology;

        [ObservableProperty]
        private string _fullVersion;

        [ObservableProperty]
        private bool _popupIsOpen;

        public MainViewModel(
            INavigationService navigationService,
            IVersionService versionService)
        {
            _navigationService = navigationService;
            _versionService = versionService;

            AppVersion = _versionService.GetAppVersion() + " ⓘ";
        }

        [RelayCommand]
        public async Task GoToMovementRecordMaxesViewAsync()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordMaxesView);
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
        public async Task OpenSupportPageAsync()
        {
            var uri = new Uri(EnvironmentConstants.SPONSOR_URL);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenProjectPageAsync()
        {
            var uri = new Uri(EnvironmentConstants.PROJECT_URL);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenProjectIssuesPageAsync()
        {
            var uri = new Uri(EnvironmentConstants.PROJECT_ISSUES_URL);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenCommitOnRepositoryAsync()
        {
            var commitHash = _versionService.GetCommitHash();
            var commitUrl = $"{EnvironmentConstants.PROJECT_URL}/commit/{commitHash}";
            var uri = new Uri(commitUrl);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task OpenPrivacyPolicyAsync()
        {
            var privacyPolicyUrl = $"{EnvironmentConstants.PRIVACY_POLICY_URL}";
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
            Copyright = EnvironmentConstants.COPYRIGHT + DateTime.Now.Year.ToString();
            Technology = AppResources.DevelopedWithDotNetMaui;
            var informationalVersion = _versionService.GetInformationalVersion();
            FullVersion = $"{AppResources.FullVersion}: {informationalVersion}";

            PopupIsOpen = true;
        }
    }
}