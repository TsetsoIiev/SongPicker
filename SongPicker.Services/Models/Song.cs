namespace SongPicker.Services.Models
{
    using MongoDB.Bson;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }

        public string Album { get; set; }

        public int Year { get; set; }
    }
}
