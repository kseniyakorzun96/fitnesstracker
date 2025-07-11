namespace FitnessTrackerApp.Models
{
    public class Entry
    {
        public string UserId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
