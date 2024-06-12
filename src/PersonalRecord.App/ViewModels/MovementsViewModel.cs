namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public partial class MovementsViewModel : ObservableObject
    {
        private ObservableCollection<Movement> _movements;
        private readonly IMovementRepository _movementRepository;

        public MovementsViewModel(IMovementRepository movementRepository)
        {
            // TODO: load from Firestore
            Movements =
            [
                new()
                {
                    Name = "Deadlift",
                },
                new()
                {
                    Name = "Backsquat",
                }
            ];
            
            _movementRepository = movementRepository;
        }

        [RelayCommand]
        public void AddNewMovement()
        {
            // TODO: read from UI
            var movement = new Movement { MovementID = Guid.NewGuid(), Name = "Deadlift"};
            Movements.Add(movement);
            _movementRepository.AddMovement(movement);
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }
    }
}