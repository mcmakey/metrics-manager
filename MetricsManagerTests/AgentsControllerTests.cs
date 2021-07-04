using System;
using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerTests
    {

        private AgentsController _controller;

        public AgentsControllerTests()
        {
            _controller = new AgentsController();
        }

        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            // Arrange
            var agentId = 1;
            var uri = new Uri("http://www.contoso.com/"); // TODO
            var agentInfo = new AgentInfo(agentId, uri);

            // Act
            var result = _controller.RegisterAgent(agentInfo);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);

        }

        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            // Arrange
            var agentId = 1;

            // Act
            var result = _controller.EnableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);

        }

        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            // Arrange
            var agentId = 1;

            // Act
            var result = _controller.DisableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);

        }

        [Fact]
        public void GetListAgents_ReturnsOk()
        {
            // Arrange

            // Act
            var result = _controller.GetListAgents();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);

        }
    }
}
