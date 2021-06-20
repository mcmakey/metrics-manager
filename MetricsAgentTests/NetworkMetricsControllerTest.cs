using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using Moq;
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
    }
}
