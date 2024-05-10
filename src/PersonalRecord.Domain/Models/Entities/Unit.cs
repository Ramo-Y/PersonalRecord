namespace PersonalRecord.Domain.Models.Entities
{
    using global::PersonalRecord.Domain.Converters;
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class Unit
    {
        [FirestoreProperty(ConverterType = typeof(GuidConverter))]
        public Guid UnitID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
    }
}