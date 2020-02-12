using MongoDB.Driver;
using SongPicker.Services.Interfaces;
using SongPicker.Services.Models;
using System;
using System.Threading.Tasks;

namespace SongPicker.Services.Services
{
    public class SongService : ISongService
    {
        public async Task<bool> AddSong(Song song)
        {
            var client = new MongoClient("mongodb://localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000");
            var database = client.GetDatabase("SongPicker");
            var collection = database.GetCollection<Song>("Songs");

            await collection.InsertOneAsync(song);

            return true;
        }
    }
}
