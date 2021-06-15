using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsController
    {
        private CpuMetricsController _controller;

        public NetworkMetricsController()
        {
            _controller = new CpuMetricsController();
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            // Arrange
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            // Act
            var result = _controller.GetMetrics(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);

        }
    }
}
