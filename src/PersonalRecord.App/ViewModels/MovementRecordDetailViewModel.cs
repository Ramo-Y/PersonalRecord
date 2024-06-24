namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;

    public partial class MovementRecordDetailViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementRecordRepository _movementRecordRepository;
        private readonly ISettingsService _settingsService;

        private ObservableCollection<Movement> _movements;
        private MovementRecord _movementRecord;
        private Setting _setting;

        public MovementRecordDetailViewModel(
            INavigationService navigationService,
            IMovementRepository movementRepository,
            IMovementRecordRepository movementRecordRepository,
            ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;
            _movementRecordRepository = movementRecordRepository;
            _settingsService = settingsService;

            Movements = [];

            LoadItems();

            MovementRecord = new MovementRecord
            {
                MovementRecordID = Guid.NewGuid(),
                MvrDate = DateTime.Now,
                MvrReps = DefaultConstants.DEFAULT_REP_COUNT
            };
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

                Setting = _settingsService.LoadSettings();
            });
        }

        public Setting Setting
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
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
        public async Task SaveAndGoBack()
        {
            await _movementRecordRepository.AddMovementRecordAsync(MovementRecord);
            await _navigationService.GoBackAsync();
        }
    }
}