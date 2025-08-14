using FitnessTracker.Database;
using FitnessTracker.Database.Models;
using FitnessTracker.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.UnitTests
{
    [TestClass]
    public class TrainingRepositoryTests
    {
        private TrainingRepository _repository;
        private AppDbContext _context;

        public TrainingRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _repository = new TrainingRepository(_context);
        }

        [TestMethod]
        public async Task GetTrainingByIdAsync_ShouldReturnCorrectTraining()
        {
            var id = Guid.NewGuid().ToString();
            var userId = "user1";
            var training = new TrainingRecord { Id = id, UserId = userId, DateOfEntry = DateTime.Today, TrainingType = "Cardio" };
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            var result = await _repository.GetTrainingByIdAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
        }

        [TestMethod]
        public async Task AddTrainingAsync_ShouldAddTraining()
        {
            var id = Guid.NewGuid().ToString();
            var userId = "user2";
            var training = new TrainingRecord
            {
                Id = id,
                UserId = userId,
                DateOfEntry = DateTime.Today,
                TrainingType = "Cardio",
            };

            await _repository.AddTrainingAsync(training);

            var result = await _repository.GetTrainingByIdAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
        }

        [TestMethod]
        public async Task UpdateTrainingAsync_ShouldModifyTraining()
        {
            var id = Guid.NewGuid().ToString();
            var userId = "user3";
            var training = new TrainingRecord { Id = id, UserId = userId, DateOfEntry = DateTime.Today, TrainingType = "Cardio", CaloriesBurned = 30, Duration = 20 };
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            var updated = new TrainingRecord { Id = id, UserId = userId, DateOfEntry = DateTime.Today.AddDays(1), TrainingType = "Cardio", CaloriesBurned = 40, Duration = 25 };
            await _repository.UpdateTrainingAsync(updated);

            var result = await _context.Trainings.FindAsync(id);
            Assert.AreEqual(userId, result.UserId);
            Assert.AreEqual(DateTime.Today.AddDays(1), result.DateOfEntry);
        }


        [TestMethod]
        public async Task DeleteTrainingAsync_ShouldRemoveTraining()
        {
            var id = Guid.NewGuid().ToString();
            var userId = "user4";

            var training = new TrainingRecord { Id = id, UserId = userId, DateOfEntry = DateTime.Today, TrainingType = "Cardio" };
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            await _repository.DeleteTrainingAsync(id);

            var result = await _context.Trainings.FindAsync(id);
            Assert.IsNull(result);
        }
    }
}
