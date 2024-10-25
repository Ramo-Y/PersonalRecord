namespace PersonalRecord.Domain.Interfaces
{
    using PersonalRecord.Domain.Models.Entities;

    public interface IExerciseRepository
    {
        Task AddExerciseAsync(Exercise exercise);

        Task AddOrUpdateAllAsync(IEnumerable<Exercise> exercise);

        Task<IEnumerable<Exercise>> GetAllExercisesAsync();

        bool IsExerciseInUse(Exercise exercise);

        Task DeleteExerciseAsync(Exercise exercise);
    }
}