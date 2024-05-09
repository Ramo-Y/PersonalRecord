namespace PersonalRecord.Domain.Models.Entities
{
    public class PersonalRecord
    {
        public Guid PersonalRecordID { get; set; }

        public float Value { get; set; }

        public Movement Movement { get; set; }

        public Guid MovementID_FK { get; set; }
    }
}