namespace SongPicker.Services.Models
{
    using MongoDB.Bson;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public ObjectId Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Album { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
