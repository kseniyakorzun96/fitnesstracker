
using FitnessTracker.Database.Models;

namespace FitnessTrackerApp.Repositories
{
    public interface INutritionRepository
    {
        Task<List<NutritionRecord>> GetNutritionAsyncForDate(string userId, DateTime date);
        Task<List<NutritionRecord>> GetNutritionAsync(string userId);
        Task CreateNutritionRecord(NutritionRecord record);
        Task UpdateNutritionRecord(NutritionRecord record);
        Task DeleteNutritionRecord(string id);
    }
}
