using MongoDB.Driver;
using SongPicker.Services.Interfaces;
using SongPicker.Services.Models;
using System.Threading.Tasks;

namespace SongPicker.Services.Services
{
    public class UserService : IUserService
    {
        public bool CreateUser(UserCreate user)
        {
            ////TODO: validator
            
            if (user.Password != user.RepeatedPassword)
            {
                return false;
            }

            //// insert into db

            return true;
        }

        public bool Login(UserLogin user)
        {
            ////TODO: validator 
            
            if (user == null)
            {
                return false;
            }

            //// login

            return true;
        }

        private IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName) where T : class
        {
            var client = new MongoClient("mongodb://localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000");
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<T>(collectionName);

            return collection;
        }
    }
}
