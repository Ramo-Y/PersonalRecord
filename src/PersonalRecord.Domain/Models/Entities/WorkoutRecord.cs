namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WorkoutRecord
    {
        [Key]
        public Guid WorkoutRecordID { get; set; }

        public Guid WreWorkoutID_FK { get; set; }

        [ForeignKey(nameof(WreWorkoutID_FK))]
        public Workout Workout { get; set; }

        public DateTime WreDate { get; set; }

        public TimeOnly WreTime { get; set; }

        public bool WreCompletedRx { get; set; }

        public float WreScaledWeight { get; set; }

        public string WreNotes { get; set; }
    }
}