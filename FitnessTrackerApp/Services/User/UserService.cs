using FitnessTrackerApp.Models;

namespace FitnessTrackerApp.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserByIdAsync(string id)
        {
            await Task.Delay(100);
            return new User { Id = id, Name = "Kseniya", Surname = "Korzun", Email = "kseniya.korzun@example.com" };
        }
    }
}
