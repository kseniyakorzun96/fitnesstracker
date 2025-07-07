namespace FitnessTrackerApp.Services
{
    public interface IUserService
    {
        Task<FitnessTrackerApp.Models.User> GetUserByIdAsync(string id);
    }
}
