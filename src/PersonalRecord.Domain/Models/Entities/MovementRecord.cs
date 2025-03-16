namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MovementRecord
    {
        [Key]
        public Guid MovementRecordID { get; set; }

        public float MvrWeight { get; set; }

        public int MvrReps { get; set; }

        public DateTime MvrDate { get; set; }

        public string? MvrNotes { get; set; }

        public Guid MvrMovementID_FK { get; set; }

        [ForeignKey(nameof(MvrMovementID_FK))]
        public Movement Movement { get; set; }
    }
}