namespace PersonalRecord.Domain.Interfaces
{
    using PersonalRecord.Domain.Models.Entities;

    public interface IWorkoutToExerciseItemsRepository
    {
        Task<IEnumerable<WorkoutToExercise>> GetAllWorkoutToExerciseItemsAsync();

        Task WorkoutToExerciseItemsFromWorkout(Workout workout);
    }
}