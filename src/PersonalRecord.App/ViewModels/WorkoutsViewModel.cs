namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public partial class WorkoutsViewModel : ObservableObject
    {
        private readonly IWorkoutRepository _workoutRepository;

        [ObservableProperty]
        private bool _deletePopupIsOpen;

        [ObservableProperty]
        private Workout _selectedWorkout;

        [ObservableProperty]
        private ObservableCollection<Workout> _workouts;

        public WorkoutsViewModel(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;

            Workouts = [];

            LoadItems();
        }

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var workouts = await _workoutRepository.GetAllWorkoutsAsync();
                foreach (var workout in workouts)
                {
                    Workouts.Add(workout);
                }
            });
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        public void ConfirmEntryDeletion(Workout workout)
        {
            DeletePopupIsOpen = true;
        }

        public bool CanDelete(Workout workout)
        {
            var isInUse = _workoutRepository.IsWorkoutInUse(workout);
            return !isInUse;
        }

        [RelayCommand]
        public async Task DeleteEntryAsync()
        {
            await _workoutRepository.DeleteWorkoutAsync(SelectedWorkout);
            Workouts.Remove(SelectedWorkout);
        }
    }
}