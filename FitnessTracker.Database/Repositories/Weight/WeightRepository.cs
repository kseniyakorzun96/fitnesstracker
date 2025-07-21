using FitnessTracker.Database.Models;

namespace FitnessTrackerApp.Repositories
{
    public class WeightRepository : IWeigthRepository
    {
        public async Task<List<WeightRecord>> GetWeightsAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
