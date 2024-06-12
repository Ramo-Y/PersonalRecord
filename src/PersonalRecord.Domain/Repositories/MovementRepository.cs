namespace PersonalRecord.Domain.Repositories
{
    using Google.Api.Gax;
    using Google.Cloud.Firestore;
    using PersonalRecord.Domain.Models.Entities;

    public class MovementRepository
    {
        public async Task CreateDb()
        {
            // Documentation: https://cloud.google.com/dotnet/docs/reference/Google.Cloud.Firestore/latest/datamodel
            // should use a real id
            var projectId = Guid.NewGuid().ToString();
            var db = new FirestoreDbBuilder
            {
                ProjectId = projectId,
                EmulatorDetection = EmulatorDetection.EmulatorOrProduction
            }.Build();
            // Use db as normal

            // Create a document with a random ID in the "Movements" collection.
            CollectionReference collection = db.Collection("Movements");
            DocumentReference document = await collection.AddAsync(new Movement{ MovementID = Guid.NewGuid(), Name = "Deadlift"});

            // A DocumentReference doesn't contain the data - it's just a path.
            // Let's fetch the current document.
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();

            // We can access individual fields by dot-separated path
            Console.WriteLine(snapshot.GetValue<string>("Name.First"));

            // Or deserialize the whole document into a dictionary
            Dictionary<string, object> data = snapshot.ToDictionary();
            Dictionary<string, object> name = (Dictionary<string, object>)data["Name"];
            Console.WriteLine(name["First"]);
            Console.WriteLine(name["Last"]);

            // See the "data model" guide for more options for data handling.

            // Query the collection for all documents where doc.Born < 1900.
            Query query = collection.WhereLessThan("Born", 1900);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
            {
                string firstName = queryResult.GetValue<string>("Name.First");
                string lastName = queryResult.GetValue<string>("Name.Last");
                int born = queryResult.GetValue<int>("Born");
                Console.WriteLine($"{firstName} {lastName}; born {born}");
            }
        }
    }
}