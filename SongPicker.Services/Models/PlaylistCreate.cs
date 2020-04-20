using System;

namespace SongPicker.Services.Models
{
    public class PlaylistCreate
    {
        public string Name { get; set; }

        public Song[] Songs { get; set; }

        public User UserCreated { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
