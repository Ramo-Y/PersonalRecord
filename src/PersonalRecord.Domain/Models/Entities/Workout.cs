namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Workout
    {
        [Key]
        public Guid WorkoutID { get; set; }

        public string WokName { get; set; }

        public string WokNotes { get; set; }
    }
}