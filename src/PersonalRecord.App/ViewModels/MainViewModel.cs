namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Services.Interfaces;

    public partial class MainViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        [RelayCommand]
        public async Task OpenProjectPageAsync()
        {
            var uri = new Uri(EnvironmentConstants.PROJECT_URL);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        [RelayCommand]
        public async Task OpenProjectIssuesPageAsync()
        {
            var uri = new Uri(EnvironmentConstants.PROJECT_ISSUES_URL);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}