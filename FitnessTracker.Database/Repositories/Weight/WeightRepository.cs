using FitnessTracker.Database;
using FitnessTracker.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApp.Repositories
{
    public class WeightRepository : IWeigthRepository
    {
        private readonly AppDbContext _context;

        public WeightRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddWeightAsync(WeightRecord weightRecord)
        {
            _context.Weight.Add(weightRecord);
            _context.SaveChangesAsync();
        }

        public async Task DeleteWeightAsync(string id)
        {
            _context.Weight.Remove(new WeightRecord { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<List<WeightRecord>> GetWeightsAsync(string userId)
        {
            return await _context.Weight
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdateWeightAsync(WeightRecord weightRecord)
        {
            _context.Weight.Update(weightRecord);
            await _context.SaveChangesAsync();
        }
    }
}
