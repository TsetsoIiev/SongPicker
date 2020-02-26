namespace SongPicker.Services.Interfaces
{
    using SongPicker.Services.Models;
    using System.Collections.Generic;

    public interface ISongService
    {
        bool AddSong(Song song);

        List<Song> GetByName(string name);
    }
}
