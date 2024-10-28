namespace PersonalRecord.Domain.Interfaces
{
    using PersonalRecord.Domain.Models.Entities;

    public interface IWorkoutRepository
    {
        Task AddWorkoutAsync(Workout workout);

        Task<Workout> GetWorkoutByIdAsync(Guid workoutID);

        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();

        Task DeleteWorkoutAsync(Workout workout);

        bool IsWorkoutInUse(Workout workout);
    }
}