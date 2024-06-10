namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public partial class MovementsViewModel : ObservableObject
    {
        private ObservableCollection<Movement> _movements;

        public MovementsViewModel()
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
        }

        [RelayCommand]
        public void AddNewMovement()
        {
            Movements.Add(new Movement());
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }
    }
}