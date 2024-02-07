using AddBusDriver.Interfaces;
using AddBusDriver.Models;
using Google.Api.Gax;
using Google.Cloud.Firestore;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

namespace AddBusDriver.Repositories.Firestore
{
    public class AddDriverRepository : IAddDriverRepository
    {
        string projectId;
        FirestoreDb firestoreDb;
        public AddDriverRepository() 
        {
            string filepath = "C:/Users/sthem/Downloads/my-route-a26c2-firebase-adminsdk-euvj1-c49dd779e3.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "my-route-a26c2";
            firestoreDb = FirestoreDb.Create(projectId);
        }
        public async Task CreateAddDriver(AddDriver addDriver)
        {
            CollectionReference colRef = firestoreDb.Collection("GetDrivers");
            await colRef.AddAsync(addDriver);
        }
    }
}
