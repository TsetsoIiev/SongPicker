namespace SongPicker.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SongCreate
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
        public string Year { get; set; }
    }
}
