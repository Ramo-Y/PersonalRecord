namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Workout
    {
        [Key]
        public Guid WorkoutID { get; set; }

        public string WokName { get; set; }

        public string WokHeader { get; set; }

        public string WokNotes { get; set; }

        public List<WorkoutToExercise> WokWorkoutToExerciseItems { get; set; }

        [NotMapped]
        public bool IsExpanded { get; set; }
    }
}