namespace SongPicker.Services.Extensions
{
    using SongPicker.Services.Enumerations;
    using System;

    public static class EnumExtensions
    {
        public static string ToString(this SongAttribute songAttribute) => songAttribute switch
        {
            SongAttribute.Name   => "name",
            SongAttribute.Year   => "year",
            SongAttribute.Album  => "album",
            SongAttribute.Artist => "artist",
            SongAttribute.Genre  => "genre",
            _                    => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(songAttribute))
        };
    }
}
