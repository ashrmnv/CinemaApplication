using AutoMapper;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.UserDtos;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }
        public void CreateUser(UserRegistrationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _repository.Add(user);
        }

        public UserDto GetByEmail(string email)
        {
            var user = _repository.Find(u => u.Email == email);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public UserDto GetById(int id)
        {
            var user = _repository.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
