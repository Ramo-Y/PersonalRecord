namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;
    using System.Linq;

    public partial class StatsViewModel : ObservableObject
    {
        private readonly IMovementRecordRepository _movementRecordRepository;
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        private ObservableCollection<MovementRecord> _movementRecords;

        [ObservableProperty]
        private Setting _setting;

        public StatsViewModel(
            IMovementRecordRepository movementRecordRepository,
            ISettingsService settingsService)
        {
            _movementRecordRepository = movementRecordRepository;
            _settingsService = settingsService;

            MovementRecords = [];

            LoadItems();
        }

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                MovementRecords.Clear();

                var movementRecords = await _movementRecordRepository.GetAllMovementRecordsAsync();
                movementRecords = movementRecords.OrderBy(m => m.Movement.MovName)
                                                 .ThenByDescending(m => m.MvrDate);

                // TODO: Hack until records will be added dynamically to the view
                var firstMovement = movementRecords.FirstOrDefault().Movement;

                foreach (var movementRecord in movementRecords)
                {
                    if (movementRecord.Movement == firstMovement)
                    {
                        MovementRecords.Add(movementRecord);
                    }
                }

                Setting = _settingsService.GetSettings();
            });
        }
    }
}
