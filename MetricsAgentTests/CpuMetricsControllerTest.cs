using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerTest
    {
        private CpuMetricsController _controller;
        private Mock<ICpuMetricsRepository> _mock;

        public CpuMetricsControllerTest()
        {
            _mock = new Mock<ICpuMetricsRepository>();
            _controller = new CpuMetricsController(_mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            var result = _controller.Create(
                    new CpuMetricsCreateRequest { Time = 1, Value = 50 }
                );

            _mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}
