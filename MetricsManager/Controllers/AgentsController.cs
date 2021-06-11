using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly Agents _agents;

        // TODO: Как инициализировать _controller = new AgentsController(agents); в AgentsControllerTest.cs ? Откуда брать agents ?
        //public AgentsController(Agents agents)
        //{
        //    _agents = agents;
        //} 

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            return Ok("agent register");
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok("agent enable");
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok("agent disable");
        }

        [HttpGet("get")]
        public IActionResult GetListAgents()
        {
            return Ok("list agents"); // TODO: _agents
        }
    }
}
