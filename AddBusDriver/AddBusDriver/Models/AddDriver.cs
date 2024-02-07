using Google.Cloud.Firestore;

namespace AddBusDriver.Models
{
    [FirestoreData]
    public class AddDriver
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public string  FirstName { get; set; 
        }
        [FirestoreProperty]
        public string LastName { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

    }
}
