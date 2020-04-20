namespace SongPicker.Services.Services
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using SongPicker.Services.Interfaces;
    using SongPicker.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PlaylistService : IPlaylistService
    {
        public Playlist CreatePlaylist(PlaylistCreate playlistCreate)
        {
            if (playlistCreate == null)
            {
                return null;
            }

            var playlist = new Playlist
            {
                Id = new ObjectId(),
                Name = playlistCreate.Name,
                Songs = new List<Song>(),
                DateCreated = DateTime.Now
            };

            try
            {
                var collection = GetCollection<Playlist>("SongPicker", "Playlists");
                collection.InsertOne(playlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return playlist;
        }

        public Playlist AddSongToPlaylist(Playlist playlist, Song song)
        {
            var collection = GetCollection<Playlist>("SongPicker", "Playlists");
            var songs = collection.AsQueryable().FirstOrDefault().Songs.ToList();
            songs.Add(song);

            UpdatePlaylist(playlist, collection, songs);

            return playlist;
        }

        public Playlist AddSongByNameToPlaylist(string playlistIdStr, string songName)
        {
            ObjectId.TryParse(playlistIdStr, out ObjectId playlistId);

            var songCollection = GetCollection<Song>("SongPicker", "Songs");
            var songToAdd = songCollection.Find(x => x.Name == songName).FirstOrDefault();

            var playlistcollection = GetCollection<Playlist>("SongPicker", "Playlists");
            var playlist = playlistcollection.Find(x => x.Id == playlistId).SingleOrDefault();

            var songs = playlistcollection.AsQueryable().FirstOrDefault().Songs.ToList();
            songs.Add(songToAdd);

            UpdatePlaylist(playlist, playlistcollection, songs);

            return playlist;
        }

        private void UpdatePlaylist(Playlist playlist, IMongoCollection<Playlist> playlistcollection, List<Song> songs)
        {
            var filter = Builders<Playlist>.Filter.Eq("ObjectId", playlist.Id);
            var update = Builders<Playlist>.Update.Set("songs", songs);

            playlistcollection.UpdateOne(filter, update);
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
