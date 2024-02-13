using AddBusSchedule.Interfaces;
using AddBusSchedule.Models;
using Google.Cloud.Firestore;
using AddBusSchedule.Interfaces;

namespace AddBusSchedule.Repositories.Firestore
{
    public class ScheduleRepository : IScheduleRepository
    {
        string projectId;
        FirestoreDb firestoreDb;
        public ScheduleRepository() 
        {
            string filepath = "C:\\Users\\sthem\\Downloads\\my-route-a26c2-firebase-adminsdk-euvj1-7d0492249d.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "my-route-a26c2";
            firestoreDb=FirestoreDb.Create(projectId);


        }
        public async Task CreateSchedule(Schedule schedule)
        {
            CollectionReference colRef = firestoreDb.Collection("schedule");
            await colRef.AddAsync(schedule);     
        }
    }
}
