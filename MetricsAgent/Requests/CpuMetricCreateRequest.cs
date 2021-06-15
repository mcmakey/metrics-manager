using System;

namespace MetricsAgent.Requests
{
    public class CpuMetricCreateRequest
    {
        public long Time { get; set; }
        public int Value { get; set; }
    }
}
