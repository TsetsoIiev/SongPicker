namespace SongPicker.Services.Models
{
    using System.ComponentModel.DataAnnotations;
    using MongoDB.Bson;

    public class Song
    {
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
