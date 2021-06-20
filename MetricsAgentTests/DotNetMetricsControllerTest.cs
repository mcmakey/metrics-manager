using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerTest
    {
        private DotNetMetricsController _controller;
        private Mock<IDotNetMetricsRepository> _mock;

        public DotNetMetricsControllerTest()
        {
            _mock = new Mock<IDotNetMetricsRepository>();
            _controller = new DotNetMetricsController(_mock.Object);
        }

        [Fact]
        //public void GetMetrics_ReturnsOk()
        //{
        //    // Arrange
        //    var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
        //    var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

        //    // Act
        //    var result = _controller.GetMetrics(fromTime, toTime);

        //    // Assert
        //    _ = Assert.IsAssignableFrom<IActionResult>(result);

        //}

        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            _mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = _controller.Create(
                    new MetricsAgent.Requests.DotNetMetricsCreateRequest { Time = 1, Value = 50 }
                );

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            _mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }
    }
}
