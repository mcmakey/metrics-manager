using MetricsAgent.DTO;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllHddMetricsResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }

    public class HddMetricsByTimePeriodResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }
}
