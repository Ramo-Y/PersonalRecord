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

    public partial class PersonalRecordDetailViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementRecordRepository _movementRecordRepository;
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveAndGoBackCommand))]
        private Movement _selectedMovement;

        [ObservableProperty]
        private ObservableCollection<Movement> _movements;

        [ObservableProperty]
        private MovementRecord _movementRecord;

        [ObservableProperty]
        private Setting _setting;

        public PersonalRecordDetailViewModel(
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

        [RelayCommand(CanExecute = nameof(CanSave))]
        public async Task SaveAndGoBackAsync(Movement movement)
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { NavigationConstants.RELOAD, true }
            };
            
            MovementRecord.Movement = movement;

            await _movementRecordRepository.AddMovementRecordAsync(MovementRecord);
            await _navigationService.GoBackAsync(navigationParameter);
        }

        public bool CanSave(Movement movement)
        {
            var isNotNull = movement is not null;
            return isNotNull;
        }
    }
}