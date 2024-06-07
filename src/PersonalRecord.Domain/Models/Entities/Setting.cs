namespace PersonalRecord.Domain.Models.Entities
{
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class Setting
    {
        [FirestoreProperty]
        public string Unit { get; set; }

        [FirestoreProperty]
        public string DateFormat { get; set; }

        [FirestoreProperty]
        public Language Language { get; set; }
    }
}