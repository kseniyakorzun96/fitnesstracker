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
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // unique DB per test
                .Options;

            _context = new AppDbContext(options);
            _repository = new TrainingRepository(_context);
        }

        [TestMethod]
        public async Task GetTrainingByIdAsync_ShouldReturnCorrectTraining()
        {
            var training = new TrainingRecord { Id = "T3", UserId = "U3", DateOfEntry = DateTime.Today, TrainingType = "Cardio" };
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            var result = await _repository.GetTrainingByIdAsync("T3");

            Assert.IsNotNull(result);
            Assert.AreEqual("U3", result.UserId);
        }

        [TestMethod]
        public async Task AddTrainingAsync_ShouldAddTraining()
        {
            var training = new TrainingRecord
            {
                Id = "T1",
                UserId = "U1",
                DateOfEntry = DateTime.Today,
                TrainingType = "Cardio",
            };

            await _repository.AddTrainingAsync(training);

            var result = await _context.Trainings.FindAsync("T1");
            Assert.IsNotNull(result);
            Assert.AreEqual("U1", result.UserId);
        }

        [TestMethod]
        public async Task UpdateTrainingAsync_ShouldModifyTraining()
        {
            var training = new TrainingRecord { Id = "T10", UserId = "U8", DateOfEntry = DateTime.Today, TrainingType = "Cardio" };
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            var updated = new TrainingRecord { Id = "T10", UserId = "U9", DateOfEntry = DateTime.Today.AddDays(1) };
            await _repository.UpdateTrainingAsync(updated);

            var result = await _context.Trainings.FindAsync("T10");
            Assert.AreEqual("U9", result.UserId);
            Assert.AreEqual(DateTime.Today.AddDays(1), result.DateOfEntry);
        }


        [TestMethod]
        public async Task DeleteTrainingAsync_ShouldRemoveTraining()
        {
            var id = Guid.NewGuid().ToString();
            var training = new TrainingRecord { Id = id, UserId = "U2", DateOfEntry = DateTime.Today, TrainingType = "Cardio" };
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            await _repository.DeleteTrainingAsync(id);

            var result = await _context.Trainings.FindAsync(id);
            Assert.IsNull(result);
        }
    }
}
