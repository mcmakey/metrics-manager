using MetricsAgent.DTO;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllNetworkMetricsResponse
    {
        public List<NetworkMetricDto> Metrics { get; set; }
    }

    public class NetworkMetricsByTimePeriodResponse
    {
        public List<NetworkMetricDto> Metrics { get; set; }
    }
}
