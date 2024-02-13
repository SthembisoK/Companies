using Google.Cloud.Firestore;

namespace AddBusSchedule.Models
{
    [FirestoreData]
    public class Schedule
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public int RouteNo { get; set; }
        [FirestoreProperty]
        public string Source { get; set; }
        [FirestoreProperty]
        public string Destination { get; set; }
        [FirestoreProperty]
        public DateTime StartTime { get; set; }
        [FirestoreProperty]
        public string Day { get; set; }
        
    }
}
