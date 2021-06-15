using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;

        public RamMetricsController(ILogger<RamMetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("agent/{agentId}/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetricsFromAgent agentId={agentId}, fromTime={fromTime}, toTime={toTime}");
            return Ok("ram GetMetricsFromAgent");
        }

        [HttpGet("cluster/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetricsFromAllCluster fromTime={fromTime}, toTime={toTime}");
            return Ok("ram GetMetricsFromAllCluster");
        }
    }
}
