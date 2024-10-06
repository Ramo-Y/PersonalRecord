namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Services.Interfaces;

    public partial class MainViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IPromptService _promptService;
        private readonly IVersionService _versionService;

        private string _appVersion;

        public MainViewModel(
            INavigationService navigationService,
            IPromptService promptService,
            IVersionService versionService)
        {
            _navigationService = navigationService;
            _promptService = promptService;
            _versionService = versionService;

            AppVersion = _versionService.GetAppVersion();
        }

        public string AppVersion
        {
            get => _appVersion;
            set => SetProperty(ref _appVersion, value);
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
        public async Task GoToMovementRecordAllViewAsync()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordAllView);
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
    }
}