using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;

        public DotNetMetricsController(ILogger<DotNetMetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("agent/{agentId}/errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetricsFromAgent agentId={agentId}, fromTime={fromTime}, toTime={toTime}");
            return Ok("dotnet GetMetricsFromAgent");
        }

        [HttpGet("cluster/errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetricsFromAllCluster fromTime={fromTime}, toTime={toTime}");
            return Ok("dotnet GetMetricsFromAllCluster");
        }
    }
}
