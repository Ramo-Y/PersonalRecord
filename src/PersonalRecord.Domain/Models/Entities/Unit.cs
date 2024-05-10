namespace PersonalRecord.Domain.Models.Entities
{
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class Unit
    {
        [FirestoreProperty]
        public Guid UnitID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
    }
}