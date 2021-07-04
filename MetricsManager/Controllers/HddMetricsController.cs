using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsController()
        {

        }

        public HddMetricsController(ILogger<HddMetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("agent/{agentId}/left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"GetMetricsFromAgent agentId={agentId}, fromTime={fromTime}, toTime={toTime}");
            }

            return Ok("hdd GetMetricsFromAgent");
        }

        [HttpGet("cluster/left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"GetMetricsFromAllCluster fromTime={fromTime}, toTime={toTime}");
            }
            return Ok("hdd GetMetricsFromAllCluster");
        }
    }
}
