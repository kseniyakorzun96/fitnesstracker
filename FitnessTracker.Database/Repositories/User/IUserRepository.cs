using FitnessTracker.Database.Models;

namespace FitnessTracker.Database.Repositories
{
    public interface IUserRepository
    {
        Task<UserRecord> GetUserAsync(string userId);
        Task RegisterUser(UserRecord user);
        Task UpdateUser(UserRecord user);
        Task DeleteUser(string userId);
    }
}
