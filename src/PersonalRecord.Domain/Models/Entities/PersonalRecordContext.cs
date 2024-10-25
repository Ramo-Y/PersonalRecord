namespace PersonalRecord.Domain.Models.Entities
{
    using Microsoft.EntityFrameworkCore;

    public class PersonalRecordContext : DbContext
    {
        public PersonalRecordContext(DbContextOptions<PersonalRecordContext> options)
            : base(options)
        {
        }

        public DbSet<Movement> MovementItems { get; set; }

        public DbSet<MovementRecord> MovementRecordItems { get; set; }

        public DbSet<Workout> WorkoutItems { get; set; }

        public DbSet<Exercise> ExerciseItems { get; set; }

        public DbSet<WorkoutToExercise> WorkoutToExerciseItems { get; set; }
    }
}