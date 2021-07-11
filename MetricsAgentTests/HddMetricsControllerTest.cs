using AutoMapper;
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
    public class HddMetricsControllerTest
    {
        private HddMetricsController _controller;
        private Mock<IHddMetricsRepository> _mockRepository;
        private Mock<ILogger<HddMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public HddMetricsControllerTest()
        {
            _mockRepository = new Mock<IHddMetricsRepository>();
            _mockLogger = new Mock<ILogger<HddMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new HddMetricsController(_mockRepository.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepository.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            var result = _controller.Create(
                    new HddMetricsCreateRequest { Time = 1, Value = 50 }
                );

            _mockRepository.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetAll_ShouldCall_From_Repository()
        {
            var metrics = new List<HddMetric>
            {
                new HddMetric {Id = 1, Value = 100, Time = 1},
                new HddMetric {Id = 2, Value = 200, Time = 2}
            };

            _mockRepository.Setup(repository => repository.GetAll()).Returns(metrics);

            var result = _controller.GetAll();

            _mockRepository.Verify(repository => repository.GetAll(), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_From_Repository()
        {
            var metrics = new List<HddMetric>
            {
                new HddMetric {Id = 1, Value = 100, Time = 1},
                new HddMetric {Id = 2, Value = 200, Time = 2}
            };

            _mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(metrics);

            var result = _controller.GetByTimePeriod(
                    new HddMetricsGetByPeriodRequest { FromTime = 1, ToTime = 2 }
                );

            _mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
