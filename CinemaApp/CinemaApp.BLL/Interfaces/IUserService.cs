using CinemaApp.Common.Dtos.UserDtos;

namespace CinemaApp.BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserRegistrationDto userDto);
        UserDto GetByEmail(string email);
        UserDto GetById(int id);

    }
}
