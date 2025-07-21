using FitnessTracker.Database;
using FitnessTracker.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApp.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly AppDbContext _context;

        public TrainingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddTrainingAsync(TrainingRecord entity)
        {
            _context.Trainings.Add(entity);
            _context.SaveChanges();
        }

        public async Task DeleteTrainingAsync(string trainingId)
        {
            _context.Trainings.Remove(new TrainingRecord { Id = trainingId });
            _context.SaveChanges();
        }

        public async Task<TrainingRecord> GetTrainingByIdAsync(string trainingId)
        {
            return await _context.Trainings.FirstOrDefaultAsync(t => t.Id == trainingId);
        }

        public async Task<List<TrainingRecord>> GetTrainingForDate(DateTime date, string userId)
        {
            return await _context.Trainings
                .Where(t => t.DateOfEntry == date && t.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<TrainingRecord>> GetTrainingsForUserAsync(string userId)
        {
            return await _context.Trainings.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task UpdateTrainingAsync(TrainingRecord training)
        {
            var existingTraining = _context.Trainings.FirstOrDefault(t => t.Id == training.Id);
            if (existingTraining != null)
            {
                existingTraining.DateOfEntry = training.DateOfEntry;
                existingTraining.UserId = training.UserId;
                _context.Trainings.Update(existingTraining);
                _context.SaveChanges();
            }
        }
    }
}
