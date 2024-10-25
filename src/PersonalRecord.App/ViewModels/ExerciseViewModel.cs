namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;

    public partial class ExerciseViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IExerciseRepository _exerciseRepository;

        [ObservableProperty]
        private bool _popupIsOpen;

        [ObservableProperty]
        private ObservableCollection<Exercise> _exercises;

        [ObservableProperty]
        private Exercise _selectedExercise;

        public ExerciseViewModel(
            INavigationService navigationService,
            IExerciseRepository exerciseRepository)
        {
            _navigationService = navigationService;
            _exerciseRepository = exerciseRepository;

            Exercises = [];

            LoadItems();
        }

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var exercises = await _exerciseRepository.GetAllExercisesAsync();
                foreach (var exercise in exercises)
                {
                    Exercises.Add(exercise);
                }
            });
        }

        [RelayCommand]
        public void AddNewExercise()
        {
            var exercise = new Exercise
            {
                ExerciseID = Guid.NewGuid()
            };

            Exercises.Add(exercise);
        }

        [RelayCommand]
        public async Task SaveAndGoBackAsync()
        {
            await _exerciseRepository.AddOrUpdateAllAsync(Exercises);
            await _navigationService.GoBackAsync();
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        public void ConfirmEntryDeletion(Exercise exercise)
        {
            SelectedExercise = exercise;
            PopupIsOpen = true;
        }


        [RelayCommand]
        public async Task DeleteEntryAsync()
        {
            await _exerciseRepository.DeleteExerciseAsync(SelectedExercise);
            Exercises.Remove(SelectedExercise);
        }

        public bool CanDelete(Exercise exercise)
        {
            var isInUse = _exerciseRepository.IsExerciseInUse(exercise);
            return !isInUse;
        }
    }
}