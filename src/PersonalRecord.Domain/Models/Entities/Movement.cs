namespace PersonalRecord.Domain.Models.Entities
{
    using PersonalRecord.Domain.Converters;
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class Movement
    {
        [FirestoreProperty(ConverterType = typeof(GuidConverter))]
        public Guid MovementID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
    }
}