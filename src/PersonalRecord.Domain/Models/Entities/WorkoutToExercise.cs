namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WorkoutToExercise
    {
        [Key]
        public Guid WorkoutToExerciseID { get; set; }

        public Guid WteWorkoutID_FK { get; set; }

        [ForeignKey(nameof(WteWorkoutID_FK))]
        public Workout Workout { get; set; }

        public Guid WteExerciseID_FK { get; set; }

        [ForeignKey(nameof(WteExerciseID_FK))]
        public Exercise Exercise { get; set; }

        public float WteExerciseRepCount { get; set; }
    }
}