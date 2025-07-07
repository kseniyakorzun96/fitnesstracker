namespace FitnessTrackerApp.Models
{
    public abstract class Entry
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
