namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using MetroLog;
    using Microsoft.Extensions.Logging;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Helpers;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;

    public partial class MovementRecordAllViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementRecordRepository _movementRecordRepository;
        private ObservableCollection<MovementRecord> _movementRecords;
        private ObservableCollection<Movement> _movements;

        private MovementRecord _dummyRecord;
        private Setting _setting;
        private readonly ILogger<MovementRecordAllViewModel> _logger;

        public MovementRecordAllViewModel(
            INavigationService navigationService,
            IMovementRepository movementRepository,
            IMovementRecordRepository movementRecordRepository,
            ILogger<MovementRecordAllViewModel> logger)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;
            _movementRecordRepository = movementRecordRepository;
            _logger = logger;

            Movements = [];
            MovementRecords = [];

            LoadItems();

            DummyRecord = new MovementRecord();
        }

        public MovementRecord DummyRecord
        {
            get => _dummyRecord;
            set => SetProperty(ref _dummyRecord, value);
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
                foreach (var movementRecord in movementRecords)
                {
                    MovementRecords.Add(movementRecord);
                }

                Setting = SettingsHelper.LoadSettings();
            });
        }


        [RelayCommand]
        public async Task DeleteEntry(MovementRecord movementRecord)
        {
            _logger.LogInformation($"going to delete MovementRecord with id='{movementRecord.MovementRecordID}'");
            var record = MovementRecords.SingleOrDefault(m => m.MovementRecordID == movementRecord.MovementRecordID);
            if (record != null)
            {
                MovementRecords.Remove(movementRecord);
            }

            await _movementRecordRepository.DeleteMovementRecordAsync(movementRecord);
        }

        [RelayCommand]
        public async Task SaveAndGoBack()
        {
            await _movementRecordRepository.UpdateAllEntriesAsync(MovementRecords);
            await _navigationService.GoBackAsync();
        }

        [RelayCommand]
        public async Task GoToMovementRecordDetailsViewAsync()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordDetailView);
        }
    }
}