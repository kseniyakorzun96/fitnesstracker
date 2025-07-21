using FitnessTracker.Database.Models;

namespace FitnessTrackerApp.Repositories
{
    public interface ITrainingRepository
    {
        Task<List<TrainingRecord>> GetTrainingsForUserAsync(string userId);
        Task<List<TrainingRecord>> GetTrainingForDate(DateTime date, string userId);
        Task AddTrainingAsync(TrainingRecord entity);
        Task<TrainingRecord> GetTrainingByIdAsync(string trainingId);
        Task DeleteTrainingAsync(string trainingId);
        Task UpdateTrainingAsync(TrainingRecord training);
    }
}
