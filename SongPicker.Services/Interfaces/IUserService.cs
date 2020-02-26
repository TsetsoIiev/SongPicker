namespace SongPicker.Services.Interfaces
{
    using SongPicker.Services.Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        bool Login(UserLogin user);

        bool CreateUser(UserCreate user);
    }
}
