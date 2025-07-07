namespace FitnessTrackerApp.Models
{
    public class TrainingEntry : Entry
    {
        public TrainingType TrainingType { get; set; }
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }
    }

    public enum TrainingType
    {
        Cardio,
        Strength,
        Flexibility,
        Balance
    }
}
