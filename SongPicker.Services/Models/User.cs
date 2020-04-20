namespace SongPicker.Services.Models
{
    using MongoDB.Bson;
    using System;

    public class User
    {
        public ObjectId Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
