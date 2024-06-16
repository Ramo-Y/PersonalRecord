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

        private ObservableCollection<Movement> _movements;

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
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await _movementRepository.AddOrUpdateAllAsync(Movements);
            await _navigationService.GoToMainViewAsync();
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }
    }
}