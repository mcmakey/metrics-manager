using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
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

        //[Fact]
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

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            _mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = _controller.Create(
                    new MetricsAgent.Requests.CpuMetricsCreateRequest { Time = 1, Value = 50 }
                );

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            _mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}
