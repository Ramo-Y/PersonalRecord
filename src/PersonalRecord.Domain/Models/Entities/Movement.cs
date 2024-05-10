namespace PersonalRecord.Domain.Models.Entities
{
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class Movement
    {
        [FirestoreProperty]
        public Guid MovementID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
    }
}