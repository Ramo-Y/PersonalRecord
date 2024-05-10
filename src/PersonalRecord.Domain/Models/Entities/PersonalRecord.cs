namespace PersonalRecord.Domain.Models.Entities
{
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class PersonalRecord
    {
        [FirestoreProperty]
        public Guid PersonalRecordID { get; set; }

        [FirestoreProperty]
        public float Value { get; set; }

        [FirestoreProperty]
        public Unit Unit { get; set; }

        [FirestoreProperty]
        public int Reps { get; set; }

        [FirestoreProperty]
        public DateTime Date { get; set; }

        [FirestoreProperty]
        public Movement Movement { get; set; }
    }
}