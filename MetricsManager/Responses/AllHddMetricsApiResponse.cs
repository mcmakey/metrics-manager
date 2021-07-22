using MetricsManager.DTO;
using System.Collections.Generic;

namespace MetricsManager.Responses
{
    public class AllHddMetricsApiResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }
}
