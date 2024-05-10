namespace PersonalRecord.Domain.Models.Entities
{
    public class PersonalRecord
    {
        public Guid PersonalRecordID { get; set; }

        public float Value { get; set; }

        public Unit Unit { get; set; }

        public int Reps { get; set; }

        public DateTime Date { get; set; }

        public Movement Movement { get; set; }
    }
}