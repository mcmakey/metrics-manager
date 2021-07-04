using System;

namespace MetricsManager
{
    public class AgentInfo
    {
        public int AgentId { get; }

        public Uri AgentAddress { get; }

        public AgentInfo(int agentId, Uri agentAddress)
        {
            AgentId = agentId;
            AgentAddress = agentAddress;
        }
    }
}
