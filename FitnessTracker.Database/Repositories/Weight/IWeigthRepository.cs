using FitnessTracker.Database.Models;

namespace FitnessTrackerApp.Repositories
{
    public interface IWeigthRepository
    {
        Task<List<WeightRecord>> GetWeightsAsync(string userId);
        Task AddWeightAsync(WeightRecord weightRecord);
        Task UpdateWeightAsync(WeightRecord weightRecord);
        Task DeleteWeightAsync(string id);
    }
}
