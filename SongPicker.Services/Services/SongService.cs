namespace SongPicker.Services.Services
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using SongPicker.Services.Enums;
    using SongPicker.Services.Extensions;
    using SongPicker.Services.Interfaces;
    using SongPicker.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SongService : ISongService
    {
        public Song AddSong(SongCreate songCreate)
        {
            if (songCreate == null)
            {
                return null;
            }

            var song = new Song
            {
                Id = new ObjectId(),
                Name = songCreate.Name,
                Album = songCreate.Album,
                Artist = songCreate.Artist,
                Genre = songCreate.Genre,
                Year = songCreate.Year
            };

            try
            {
                var collection = GetCollection<Song>("SongPicker", "Songs");
                collection.InsertOne(song);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            return song;
        }

        public List<Song> GetByAttribute(string parameter, SongAttribute attribute)
        {
            var collection = GetCollection<Song>("SongPicker", "Songs");
            var attributeName = EnumExtensions.ToString(attribute);
            List<Song> result;

            result = attributeName switch
            {
                "name" => collection.Find(x => x.Name == parameter).ToList(),
                "year" => collection.Find(x => x.Year == int.Parse(parameter)).ToList(),
                "album" => collection.Find(x => x.Album == parameter).ToList(),
                "artist" => collection.Find(x => x.Artist == parameter).ToList(),
                "genre" => collection.Find(x => x.Genre == parameter).ToList(),
                _ => result = new List<Song>()
            };

            return result;
        }

        public List<Song> GetByAllAttributes(string parameter)
        {
            var collection = GetCollection<Song>("SongPicker", "Songs");
            var result = new List<Song>();

            result.AddRange(collection.Find(x => x.Name == parameter).ToList());
            result.AddRange(collection.Find(x => x.Album == parameter).ToList());
            result.AddRange(collection.Find(x => x.Artist == parameter).ToList());
            result.AddRange(collection.Find(x => x.Genre == parameter).ToList());

            if (int.TryParse(parameter, out int year))
            {
                result.AddRange(collection.Find(x => x.Year == year).ToList());
            }

            return result;
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
