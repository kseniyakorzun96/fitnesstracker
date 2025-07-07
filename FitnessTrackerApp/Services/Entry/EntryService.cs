using FitnessTrackerApp.Models;

namespace FitnessTrackerApp.Services
{
    public class EntryService : IEntryService
    {
        public Task AddEntryAsync(Entry entry)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntryAsync(string entryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entry>> GetEntriesByTypeAsync(string userId, string entryType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entry>> GetEntriesForUserAsync(string userId)
        {
            return new List<Entry>
            {
                new TrainingEntry
                {
                    Id = "1",
                    UserId = userId,
                    DateOfEntry = DateTime.UtcNow.AddDays(-1),
                    TrainingType = TrainingType.Cardio,
                    Duration = 30,
                    CaloriesBurned = 150
                },
                new TrainingEntry
                {
                    Id = "2",
                    UserId = userId,
                    DateOfEntry = DateTime.UtcNow.AddDays(-1),
                    TrainingType = TrainingType.Strength,
                    Duration = 45,
                    CaloriesBurned = 100
                },
                new NutritionEntry
                {
                    Id = "3",
                    UserId = userId,
                    DateOfEntry = DateTime.UtcNow.AddDays(-1),
                    Calories = 300,
                    FoodItem = "Chicken Salad",
                    Protein = 30,
                    Carbohydrates = 20,
                    Fats = 10
                }
            };
        }

        public Task<Entry> GetEntryByIdAsync(string entryId)
        {
            throw new NotImplementedException();
        }
    }
}
