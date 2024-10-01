namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure.Resources.Languages;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;

    public partial class MovementsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;
        private readonly IAlertService _alertService;
        private ObservableCollection<Movement> _movements;

        public MovementsViewModel(
            INavigationService navigationService,
            IMovementRepository movementRepository,
            IAlertService alertService)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;
            _alertService = alertService;

            Movements = [];
            
            LoadItems();
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
            });
        }

        [RelayCommand]
        public void AddNewMovement()
        {
            var movement = new Movement
            {
                MovementID = Guid.NewGuid()
            };

            Movements.Add(movement);
        }

        [RelayCommand]
        public async Task SaveAndGoBackAsync()
        {
            await _movementRepository.AddOrUpdateAllAsync(Movements);
            await _navigationService.GoBackAsync();
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        public async Task DeleteEntry(Movement movement)
        {
            var deleteConfirmation = await _alertService.ShowConfirmationAsync(
                AppResources.DeleteEntryTitle,
                AppResources.DeleteAskForConfirmation,
                AppResources.Delete,
                AppResources.Cancel);
            if (deleteConfirmation)
            {
                await _movementRepository.DeleteMovementAsync(movement);
                Movements.Remove(movement);
            }
        }

        public bool CanDelete(Movement movement)
        {
            var isInUse = _movementRepository.IsMovementInUse(movement);
            return !isInUse;
        }
    }
}