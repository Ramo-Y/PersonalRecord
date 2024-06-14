namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public partial class MovementsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;

        private ObservableCollection<Movement> _movements;
        private Movement _selectedMovement;

        public MovementsViewModel(INavigationService navigationService, IMovementRepository movementRepository)
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
            // TODO: read from UI
            var movement = new Movement { MovementID = Guid.NewGuid(), Name = "Deadlift"};
            Movements.Add(movement);
            _movementRepository.AddMovementAsync(movement);
        }

        [RelayCommand]
        public async Task GoBack()
        {
            // TODO: Call on go back
            await _movementRepository.SaveAsync();
            await _navigationService.GoToAsync(Routes.MainView);
        }

        public Movement SelectedMovement
        {
            get => _selectedMovement;
            set 
            {
                SetProperty(ref _selectedMovement, value);
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await _movementRepository.SaveAsync();
                });
            }
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }
    }
}