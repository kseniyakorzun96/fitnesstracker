using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Database.Models
{
    public class NutritionRecord
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime Updated { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
    }
}
