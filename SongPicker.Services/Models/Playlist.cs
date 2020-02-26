namespace SongPicker.Services.Models
{
    using MongoDB.Bson;
    using System;

    public class Playlist
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public Song[] Songs { get; set; }

        public User UserCreated { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
