using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Database.Models
{
    public class TrainingRecord
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string TrainingType { get; set; }
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }
    }
}
