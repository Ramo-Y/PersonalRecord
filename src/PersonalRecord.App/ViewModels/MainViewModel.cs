namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public partial class MainViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        private ObservableCollection<MovementRecord> _movementRecords;

        private ObservableCollection<Movement> _movements;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // TODO: Load from Firebase
            Movements =
            [
                new()
                {
                    Name = "Deadlift",
                },
                new()
                {
                    Name = "Backsquat",
                }
            ];

            MovementRecords =
            [
                new()
                {
                    Date = DateTime.Now,
                    Reps = 1,
                    Value = 100,
                    Movement = Movements?.FirstOrDefault()
                }
            ];
        }
        public ObservableCollection<MovementRecord> MovementRecords
        {
            get => _movementRecords;
            set => SetProperty(ref _movementRecords, value);
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }

        [RelayCommand]
        public async Task GoToSettingsViewAsync()
        {
            await _navigationService.GoToAsync(Routes.SettingsView);
        }
    }
}