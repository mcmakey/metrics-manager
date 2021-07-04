﻿using MetricsAgent.DTO;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllDotNetMetricsResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }

    public class DotNetMetricsByTimePeriodResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }
}
