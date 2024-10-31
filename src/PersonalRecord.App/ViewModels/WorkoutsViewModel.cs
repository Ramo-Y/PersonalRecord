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
        private readonly IWorkoutToExerciseItemsRepository _workoutToExerciseItemsRepository;

        [ObservableProperty]
        private bool _deletePopupIsOpen;

        [ObservableProperty]
        private Workout _selectedWorkout;

        [ObservableProperty]
        private ObservableCollection<Workout> _workouts;

        [ObservableProperty]
        private ObservableCollection<WorkoutToExercise> _workoutToExercises;

        public WorkoutsViewModel(
            IWorkoutRepository workoutRepository,
            IWorkoutToExerciseItemsRepository workoutToExerciseItemsRepository)
        {
            _workoutRepository = workoutRepository;
            _workoutToExerciseItemsRepository = workoutToExerciseItemsRepository;

            Workouts = [];
            WorkoutToExercises = [];

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

                var workoutToExercises = await _workoutToExerciseItemsRepository.GetAllWorkoutToExerciseItemsAsync();
                foreach (var workoutToExercise in workoutToExercises)
                {
                    WorkoutToExercises.Add(workoutToExercise);
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
            await _workoutToExerciseItemsRepository.WorkoutToExerciseItemsFromWorkout(SelectedWorkout);
            await _workoutRepository.DeleteWorkoutAsync(SelectedWorkout);
            Workouts.Remove(SelectedWorkout);
        }
    }
}