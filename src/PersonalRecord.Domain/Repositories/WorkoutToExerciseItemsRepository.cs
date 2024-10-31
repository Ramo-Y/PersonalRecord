namespace PersonalRecord.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class WorkoutToExerciseItemsRepository : IWorkoutToExerciseItemsRepository
    {
        private readonly PersonalRecordContext _context;

        public WorkoutToExerciseItemsRepository(PersonalRecordContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkoutToExercise>> GetAllWorkoutToExerciseItemsAsync()
        {
            var workoutToExerciseItems = await _context.WorkoutToExerciseItems.ToListAsync();
            return workoutToExerciseItems;
        }

        public async Task WorkoutToExerciseItemsFromWorkout(Workout workout)
        {
            await _context.WorkoutToExerciseItems.Where(w => w.WteWorkoutID_FK == workout.WorkoutID).ExecuteDeleteAsync();
        }
    }
}