using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;

        public AgentsController()
        {

        }

        public AgentsController(ILogger<AgentsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"RegisterAgent agentInfo={agentInfo}");
            }

            return Ok("agent register");
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"EnableAgentById agentId={agentId}");
            }

            return Ok("agent enable");
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"DisableAgentById agentId={agentId}");
            }

            return Ok("agent disable");
        }

        [HttpGet("get")]
        public IActionResult GetListAgents()
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"GetListAgents");
            }

            return Ok("list agents");
        }
    }
}
