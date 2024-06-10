namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public partial class MovementRecordDetailViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        private ObservableCollection<Movement> _movements;

        private MovementRecord _movementRecord;

        public MovementRecordDetailViewModel(INavigationService navigationService)
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

            // TODO: Depending on situation, can be loaded if it's editing, or a new one
            MovementRecord = new MovementRecord
            {
                Date = DateTime.Now,
            };
        }

        public MovementRecord MovementRecord
        {
            get => _movementRecord;
            set => SetProperty(ref _movementRecord, value);
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }

        [RelayCommand]
        public async Task GoToMovementRecordsView()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordsView);
        }
    }
}