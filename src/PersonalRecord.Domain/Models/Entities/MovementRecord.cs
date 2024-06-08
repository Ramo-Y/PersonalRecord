namespace PersonalRecord.Domain.Models.Entities
{
    using global::PersonalRecord.Domain.Converters;
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class MovementRecord
    {
        [FirestoreProperty(ConverterType = typeof(GuidConverter))]
        public Guid PersonalRecordID { get; set; }

        [FirestoreProperty]
        public float Weight { get; set; }

        [FirestoreProperty]
        public int Reps { get; set; }

        [FirestoreProperty]
        public DateTime Date { get; set; }

        [FirestoreProperty]
        public Movement Movement { get; set; }
    }
}