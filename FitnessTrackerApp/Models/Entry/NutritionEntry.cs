namespace FitnessTrackerApp.Models
{
    public class NutritionEntry : Entry
    {
        public string FoodItem { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
    }
}
