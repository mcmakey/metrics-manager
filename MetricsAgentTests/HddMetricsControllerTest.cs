using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerTest
    {
        private HddMetricsController _controller;
        private Mock<IHddMetricsRepository> _mock;

        public HddMetricsControllerTest()
        {
            _mock = new Mock<IHddMetricsRepository>();
            _controller = new HddMetricsController(_mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            var result = _controller.Create(
                    new HddMetricsCreateRequest { Time = 1, Value = 50 }
                );

            _mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetAll_ShouldCall_From_Repository()
        {
            var metrics = new List<HddMetric>
            {
                new HddMetric {Id = 1, Value = 100, Time = 1},
                new HddMetric {Id = 2, Value = 200, Time = 2}
            };

            _mock.Setup(repository => repository.GetAll()).Returns(metrics);

            var result = _controller.GetAll();

            _mock.Verify(repository => repository.GetAll(), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_From_Repository()
        {
            var metrics = new List<HddMetric>
            {
                new HddMetric {Id = 1, Value = 100, Time = 1},
                new HddMetric {Id = 2, Value = 200, Time = 2}
            };

            _mock.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(metrics);

            var result = _controller.GetByTimePeriod(
                    new HddMetricsGetByPeriodRequest { FromTime = 1, ToTime = 2 }
                );

            _mock.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
