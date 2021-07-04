namespace MetricsAgent.Requests
{
    public class HddMetricsCreateRequest
    {
        public long Time { get; set; }
        public int Value { get; set; }
    }

    public class HddMetricsGetByPeriodRequest
    {
        public long FromTime { get; set; }
        public long ToTime { get; set; }
    }
}
