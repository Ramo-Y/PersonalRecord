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

        private string _appVersion;
        private string _message;
        private bool _isOpen;

        public MainViewModel(
            INavigationService navigationService,
            IVersionService versionService)
        {
            _navigationService = navigationService;
            _versionService = versionService;

            AppVersion = _versionService.GetAppVersion() + " ⓘ";
        }

        public string AppVersion
        {
            get => _appVersion;
            set => SetProperty(ref _appVersion, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool IsOpen
        {
            get => _isOpen;
            set => SetProperty(ref _isOpen, value);
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

        [RelayCommand]
        public async Task OpenCommitOnRepositoryAsync()
        {
            var commitHash = _versionService.GetCommitHash();
            var commitUrl = $"{EnvironmentConstants.PROJECT_URL}/commit/{commitHash}";
            var uri = new Uri(commitUrl);
            await _navigationService.OpenSystemBrowserAsync(uri);
        }

        [RelayCommand]
        public async Task ShowDetailInformationAsync()
        {
            var copyright = _versionService.GetCopyright();
            var informationalVersion = _versionService.GetInformationalVersion();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(copyright);
            stringBuilder.AppendLine(string.Empty);
            stringBuilder.AppendLine(AppResources.DevelopedWithDotNetMaui);
            stringBuilder.AppendLine(string.Empty);
            stringBuilder.AppendLine(informationalVersion);

            Message = stringBuilder.ToString();

            IsOpen = true;
        }
    }
}