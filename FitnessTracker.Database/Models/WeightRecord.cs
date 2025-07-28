using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Database.Models
{
    public class WeightRecord
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime? Updated { get; set; } 
        public int Value { get; set; }
    }
}
