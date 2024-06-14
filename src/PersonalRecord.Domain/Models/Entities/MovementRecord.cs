namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MovementRecord
    {
        [Key]
        public Guid PersonalRecordID { get; set; }

        public float Weight { get; set; }

        public int Reps { get; set; }

        public DateTime Date { get; set; }

        public Guid MovementID_FK { get; set; }

        [ForeignKey(nameof(MovementID_FK))]
        public Movement Movement { get; set; }
    }
}