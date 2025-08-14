using AutoMapper;
using FitnessTracker.Database.Models;
using FitnessTracker.Database.Repositories;
using FitnessTracker.WebApi.Models;
using FitnessTracker.WebApi.Services;
using Moq;
using System.Collections.Generic;

namespace FitnessTracker.UnitTests
{
    [TestClass]
    public sealed class TrainingServiceTests
    {
        private readonly TrainingService _trainingService;
        private readonly Mock<ITrainingRepository> _repo;
        private readonly Mock<IMapper> _mapper;

        public TrainingServiceTests()
        {
            _mapper = new Mock<IMapper>();


            _repo = new Mock<ITrainingRepository>();
            _trainingService = new TrainingService(_repo.Object, _mapper.Object);
        }

        [TestMethod]
        [Ignore("This test is ignored for now, as it requires a valid user ID and date.")]
        public async Task GetTrainingsForUser_ReturnsSuccess()
        {
            var userId = "user1";
            var date = DateTime.UtcNow;
            var id = Guid.NewGuid().ToString();

            var trainings = new List<TrainingRecord>() 
            { 
                new TrainingRecord() 
                { 
                    Id = id,
                    UserId = userId, 
                    CaloriesBurned = 250, 
                    Duration = 20, 
                    DateOfEntry = date,
                    TrainingType = "Cardio"
                } 
            };

            _mapper.Setup(m => m.Map<TrainingRecord>(It.IsAny<Training>()))
                .Returns(new TrainingRecord
                {
                    Id = id,
                    UserId = "user1",
                    TrainingType = "Cardio",
                    Duration = 30,
                    CaloriesBurned = 250,
                    DateOfEntry = date
                });

            _repo.Setup(x => x.GetTrainingsForUserAsync(userId)).ReturnsAsync(trainings);

            var result = await _trainingService.GetTrainingsForUserAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<Training>(result);
        }
    }
}
