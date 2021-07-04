using MetricsAgent.DTO;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllRamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }

    public class RamMetricsByTimePeriodResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }
}
