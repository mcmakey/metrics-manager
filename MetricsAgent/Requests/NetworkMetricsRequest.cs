﻿namespace MetricsAgent.Requests
{
    public class NetworkMetricsCreateRequest
    {
        public long Time { get; set; }
        public int Value { get; set; }
    }

    public class NetworkMetricsGetByPeriodRequest
    {
        public long FromTime { get; set; }
        public long ToTime { get; set; }
    }
}
