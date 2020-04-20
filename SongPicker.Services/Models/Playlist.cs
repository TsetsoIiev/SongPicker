namespace SongPicker.Services.Models
{
    using MongoDB.Bson;
    using System;
    using System.Collections.Generic;

    public class Playlist
    {
        public Playlist()
        {
            this.Songs = new List<Song>();
        }

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Song> Songs { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
