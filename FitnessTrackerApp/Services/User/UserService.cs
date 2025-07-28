using AutoMapper;
using FitnessTracker.Database.Models;
using FitnessTracker.Database.Repositories;
using FitnessTracker.WebApi.Models;

namespace FitnessTracker.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var entity = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<User>(entity);
        }

        public async Task RegisterUserAsync(User user)
        {
            var entity = _mapper.Map<UserRecord>(user);
            await _userRepository.RegisterUser(entity);
        }

        public async Task UpdateUserAsync(User user)
        {
            var entity = _mapper.Map<UserRecord>(user);
            await _userRepository.UpdateUser(entity);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
