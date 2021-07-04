using MetricsAgent.DTO;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }

    public class CpuMetricsByTimePeriodResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }
}
