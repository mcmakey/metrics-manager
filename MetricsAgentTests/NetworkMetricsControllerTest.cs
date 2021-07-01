using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerTest
    {
        private NetworkMetricsController _controller;
        private Mock<INetworkMetricsRepository> _mock;

        public NetworkMetricsControllerTest()
        {
            _mock = new Mock<INetworkMetricsRepository>();
            _controller = new NetworkMetricsController(_mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();

            var result = _controller.Create(
                    new NetworkMetricsCreateRequest { Time = 1, Value = 50 }
                );

            _mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetAll_ShouldCall_From_Repository()
        {
            var metrics = new List<NetworkMetric>
            {
                new NetworkMetric {Id = 1, Value = 100, Time = 1},
                new NetworkMetric {Id = 2, Value = 200, Time = 2}
            };

            _mock.Setup(repository => repository.GetAll()).Returns(metrics);

            var result = _controller.GetAll();

            _mock.Verify(repository => repository.GetAll(), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_From_Repository()
        {
            var metrics = new List<NetworkMetric>
            {
                new NetworkMetric {Id = 1, Value = 100, Time = 1},
                new NetworkMetric {Id = 2, Value = 200, Time = 2}
            };

            _mock.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(metrics);

            var result = _controller.GetByTimePeriod(
                    new NetworkMetricsGetByPeriodRequest { FromTime = 1, ToTime = 2 }
                );

            _mock.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
