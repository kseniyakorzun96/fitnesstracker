using FitnessTracker.WebApi.Models;

namespace FitnessTracker.WebApi.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(string id);
        Task RegisterUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}
