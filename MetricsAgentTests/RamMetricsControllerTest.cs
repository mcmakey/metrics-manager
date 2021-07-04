using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsControllerTest
    {
        private RamMetricsController _controller;
        private Mock<IRamMetricsRepository> _mockRepository;
        private Mock<ILogger<RamMetricsController>> _mockLogger;

        public RamMetricsControllerTest()
        {
            _mockRepository = new Mock<IRamMetricsRepository>();
            _mockLogger = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(_mockRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepository.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();

            var result = _controller.Create(
                    new RamMetricsCreateRequest { Time = 1, Value = 50 }
                );

            _mockRepository.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetAll_ShouldCall_From_Repository()
        {
            var metrics = new List<RamMetric>
            {
                new RamMetric {Id = 1, Value = 100, Time = 1},
                new RamMetric {Id = 2, Value = 200, Time = 2}
            };

            _mockRepository.Setup(repository => repository.GetAll()).Returns(metrics);

            var result = _controller.GetAll();

            _mockRepository.Verify(repository => repository.GetAll(), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_From_Repository()
        {
            var metrics = new List<RamMetric>
            {
                new RamMetric {Id = 1, Value = 100, Time = 1},
                new RamMetric {Id = 2, Value = 200, Time = 2}
            };

            _mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(metrics);

            var result = _controller.GetByTimePeriod(
                    new RamMetricsGetByPeriodRequest { FromTime = 1, ToTime = 2 }
                );

            _mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
