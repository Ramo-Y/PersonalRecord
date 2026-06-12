namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;

    public partial class MovementsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;

        public event EventHandler SelectMovement;

        [ObservableProperty]
        public partial bool DeletePopupIsOpen { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<Movement> Movements { get; set; }

        [ObservableProperty]
        public partial Movement SelectedMovement { get; set; }

        [ObservableProperty]
        public partial bool HasUnsavedChanges { get; set; }

        [ObservableProperty]
        public partial bool HasUnsavedChangesPopupIsOpen { get; set; }

        public MovementsViewModel(
            INavigationService navigationService,
            IMovementRepository movementRepository)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;

            Movements = [];
            
            LoadItems();
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
            SelectedMovement = movement;
            HasUnsavedChanges = true;
            SelectMovement?.Invoke(this, EventArgs.Empty);
        }

        [RelayCommand]
        public async Task SaveAndGoBackAsync()
        {
            await _movementRepository.AddOrUpdateAllAsync(Movements);
            HasUnsavedChanges = false;
            await _navigationService.GoBackAsync();
        }

        [RelayCommand]
        public async Task DiscardAndGoBackAsync()
        {
            HasUnsavedChanges = false;
            await _navigationService.GoBackAsync();
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        public void ConfirmEntryDeletion(Movement movement)
        {
            SelectedMovement = movement;
            DeletePopupIsOpen = true;
        }

        [RelayCommand]
        public async Task DeleteEntryAsync()
        {
            await _movementRepository.DeleteMovementAsync(SelectedMovement);
            Movements.Remove(SelectedMovement);
        }

        public bool CanDelete(Movement movement)
        {
            var isInUse = _movementRepository.IsMovementInUse(movement);
            return !isInUse;
        }
    }
}