using FitnessTracker.Database.Models;

namespace FitnessTrackerApp.Repositories
{
    public interface IWeigthRepository
    {
        Task<List<WeightRecord>> GetWeightsAsync(string userId);
    }
}
