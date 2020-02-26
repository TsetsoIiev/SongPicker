namespace SongPicker.Services.Models
{
    public class UserCreate
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RepeatedPassword { get; set; }

        public string Email { get; set; }
    }
}
