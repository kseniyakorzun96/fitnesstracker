namespace FitnessTrackerApp.Services
{
    public interface IEntryService
    {
        Task<List<FitnessTrackerApp.Models.Entry>> GetEntriesForUserAsync(string userId);
        Task AddEntryAsync(FitnessTrackerApp.Models.Entry entry);
        Task<FitnessTrackerApp.Models.Entry> GetEntryByIdAsync(string entryId);
        Task DeleteEntryAsync(string entryId);  
        Task<List<FitnessTrackerApp.Models.Entry>> GetEntriesByTypeAsync(string userId, string entryType);
    }
}
