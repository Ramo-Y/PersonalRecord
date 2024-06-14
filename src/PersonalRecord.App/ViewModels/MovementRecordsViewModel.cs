namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure.Constants;
    using System.Collections.ObjectModel;

    public partial class MovementRecordsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        private readonly IMovementRepository _movementRepository;

        private ObservableCollection<MovementRecord> _movementRecords;

        private ObservableCollection<Movement> _movements;

        public MovementRecordsViewModel(INavigationService navigationService, IMovementRepository movementRepository)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;

            // TODO: Loading in NavigatedTo or equivalent to this method
            Movements = [];
            var movements = _movementRepository.GetAllMovements().Result;
            foreach (var movement in movements)
            {
                Movements.Add(movement);
            }

            MovementRecords =
            [
                new()
                {
                    Date = DateTime.Now,
                    Reps = DefaultConstants.DEFAULT_REP_COUNT,
                    Weight = 100,
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
        public async Task GoToMovementRecordDetailsViewAsync()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordDetailView);
        }
    }
}