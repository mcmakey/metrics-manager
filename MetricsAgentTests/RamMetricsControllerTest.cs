using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsControllerTest
    {
        private RamMetricsController _controller;
        private Mock<IRamMetricsRepository> _mock;

        public RamMetricsControllerTest()
        {
            _mock = new Mock<IRamMetricsRepository>();
            _controller = new RamMetricsController(_mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();

            var result = _controller.Create(
                    new RamMetricsCreateRequest { Time = 1, Value = 50 }
                );

            _mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}
