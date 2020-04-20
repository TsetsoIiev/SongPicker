namespace SongPicker.Services.Interfaces
{
    using SongPicker.Services.Models;

    public interface IPlaylistService
    {
        Playlist CreatePlaylist(PlaylistCreate playlist);

        Playlist AddSongToPlaylist(Playlist playlist, Song song);

        Playlist AddSongByNameToPlaylist(string playlistIdStr, string songName);
    }
}
