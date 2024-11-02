namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;

    public partial class WorkoutsViewModel : ObservableObject
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IWorkoutToExerciseItemsRepository _workoutToExerciseItemsRepository;
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        private bool _deletePopupIsOpen;

        [ObservableProperty]
        private Workout _selectedWorkout;

        [ObservableProperty]
        private Setting _setting;

        [ObservableProperty]
        private ObservableCollection<Workout> _workouts;

        public WorkoutsViewModel(
            IWorkoutRepository workoutRepository,
            IWorkoutToExerciseItemsRepository workoutToExerciseItemsRepository,
            ISettingsService settingsService)
        {
            _workoutRepository = workoutRepository;
            _workoutToExerciseItemsRepository = workoutToExerciseItemsRepository;
            _settingsService = settingsService;

            Workouts = [];

            LoadItems();
        }

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                Setting = _settingsService.LoadSettings();

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
            await _workoutToExerciseItemsRepository.WorkoutToExerciseItemsFromWorkout(SelectedWorkout);
            await _workoutRepository.DeleteWorkoutAsync(SelectedWorkout);
            Workouts.Remove(SelectedWorkout);
        }
    }
}