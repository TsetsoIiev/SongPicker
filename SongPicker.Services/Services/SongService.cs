﻿using MongoDB.Driver;
using SongPicker.Services.Interfaces;
using SongPicker.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SongPicker.Services.Services
{
    public class SongService : ISongService
    {
        public bool AddSong(Song song)
        {
            try
            {
                var collection = GetCollection<Song>("SongPicker", "Songs");
                collection.InsertOne(song);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public List<Song> GetByName(string name)
        {
            var collection = GetCollection<Song>("SongPicker", "Songs");
            var result = collection.Find(x => x.Name == name).ToList();

            return result;
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
