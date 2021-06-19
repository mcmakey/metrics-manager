namespace MetricsAgent.Requests
{
    public class CpuMetricsCreateRequest
    {
        public long Time { get; set; }
        public int Value { get; set; }
    }

    public class CpuMetricsGetByPeriodRequest
    {
        public long FromTime { get; set; }
        public long ToTime { get; set; }
    }
}
