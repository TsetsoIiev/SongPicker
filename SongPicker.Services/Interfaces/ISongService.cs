namespace SongPicker.Services.Interfaces
{
    using SongPicker.Services.Models;
    using System.Threading.Tasks;

    public interface ISongService
    {
        Task<bool> AddSong(Song song);
    }
}
