using FitnessTracker.Database;
using FitnessTracker.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApp.Repositories
{
    public class NutritionRepository : INutritionRepository
    {
        private readonly AppDbContext _context;

        public NutritionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NutritionRecord>> GetNutritionAsyncForDate(string userId, DateTime date)
        {
            return await _context.Nutrition.Where(n => n.UserId == userId && n.DateOfEntry == date).ToListAsync();
        }

        public async Task<List<NutritionRecord>> GetNutritionAsync(string userId)
        {
            return await _context.Nutrition.Where(n => n.UserId == userId).ToListAsync();
        }

        public async Task CreateNutritionRecord(NutritionRecord record)
        {
            await _context.Nutrition.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNutritionRecord(NutritionRecord record)
        {   
            _context.Nutrition.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNutritionRecord(string id)
        {      
            var nutritionRecord = await _context.Nutrition.FindAsync(id);
            if (nutritionRecord != null)
            {
                _context.Nutrition.Remove(nutritionRecord);
                await _context.SaveChangesAsync();
            }
        }
    }
}
