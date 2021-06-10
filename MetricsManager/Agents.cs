using System.Collections.Generic;

namespace MetricsManager
{
    public class Agents
    {
        public List<AgentInfo> ListAgents { get; set; }

        public Agents()
        {
            ListAgents = new List<AgentInfo> { };
        }
    }
}
