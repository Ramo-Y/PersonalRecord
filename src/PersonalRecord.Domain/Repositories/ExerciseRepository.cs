namespace PersonalRecord.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExerciseRepository : IExerciseRepository
    {
        private readonly PersonalRecordContext _context;

        public ExerciseRepository(PersonalRecordContext context)
        {
            _context = context;
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            await _context.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrUpdateAllAsync(IEnumerable<Exercise> exercises)
        {
            foreach (var exercise in exercises)
            {
                var find = await _context.ExerciseItems.FindAsync(exercise.ExerciseID);
                if (find == null)
                {
                    await _context.ExerciseItems.AddAsync(exercise);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteExerciseAsync(Exercise exercise)
        {
            await _context.ExerciseItems.Where(e => e.ExerciseID == exercise.ExerciseID).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            var exerciseItems = await _context.ExerciseItems.OrderBy(e => e.ExrName).ToListAsync();
            return exerciseItems;
        }

        public bool IsExerciseInUse(Exercise exercise)
        {
            var isInUse = _context.WorkoutToExerciseItems.Any(w => w.Exercise.Equals(exercise));
            return isInUse;
        }
    }
}