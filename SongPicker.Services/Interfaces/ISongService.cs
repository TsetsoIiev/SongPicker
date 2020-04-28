namespace SongPicker.Services.Interfaces
{
    using SongPicker.Services.Enums;
    using SongPicker.Services.Models;
    using System.Collections.Generic;

    public interface ISongService
    {
        Song AddSong(SongCreate song);

        List<Song> GetByName(string name);

        List<Song> GetByAllAttributes(string parameter);

        List<Song> GetByAttribute(string parameter, SongAttribute attribute);
        
        List<Song> GetAll();

        List<Song> GetByAttributes(string name, string artist);
    }
}
