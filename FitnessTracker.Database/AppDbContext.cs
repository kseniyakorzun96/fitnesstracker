using FitnessTracker.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<TrainingRecord> Trainings { get; set; }
        public DbSet<NutritionRecord> Nutrition { get; set; }
        public DbSet<WeightRecord> Weight { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
