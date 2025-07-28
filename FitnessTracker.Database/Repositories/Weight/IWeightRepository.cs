using FitnessTracker.Database.Models;

namespace FitnessTracker.Database.Repositories
{
    public interface IWeightRepository
    {
        Task<List<WeightRecord>> GetWeightsAsync(string userId);
        Task AddWeightAsync(WeightRecord weightRecord);
        Task UpdateWeightAsync(WeightRecord weightRecord);
        Task DeleteWeightAsync(string id);
    }
}
