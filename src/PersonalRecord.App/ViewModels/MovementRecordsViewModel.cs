namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public partial class MovementRecordsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementRecordRepository _movementRecordRepository;

        private ObservableCollection<MovementRecord> _movementRecords;
        private ObservableCollection<Movement> _movements;

        private Setting _setting;

        public MovementRecordsViewModel(
            INavigationService navigationService,
            IMovementRepository movementRepository,
            IMovementRecordRepository movementRecordRepository)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;
            _movementRecordRepository = movementRecordRepository;

            Movements = [];
            MovementRecords = [];

            LoadItems();

            // Load from database
            Setting = new Setting
            {
                DateFormat = "yyyy-MM-dd",
                Unit = "kg",
                UnitFormat = $"###.# kg"
            };
        }

        public Setting Setting
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
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

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var movements = await _movementRepository.GetAllMovementsAsync();
                foreach (var movement in movements)
                {
                    Movements.Add(movement);
                }

                var movementRecords = await _movementRecordRepository.GetAllMovementRecordsAsync();
                var highest = movementRecords.OrderByDescending(m => m.MvrWeight).DistinctBy(m => m.Movement).ToList();
                foreach (var movementRecord in highest)
                {
                    MovementRecords.Add(movementRecord);
                }
            });
        }

        [RelayCommand]
        public async Task GoToMainViewAsync()
        {
            await _navigationService.GoToMainViewAsync();
        }

        [RelayCommand]
        public async Task GoToMovementRecordDetailsViewAsync()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordDetailView);
        }
    }
}