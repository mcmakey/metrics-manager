namespace MetricsAgent.Requests
{
    public class DotNetMetricsCreateRequest
    {
        public long Time { get; set; }
        public int Value { get; set; }
    }

    public class DotNetMetricsGetByPeriodRequest
    {
        public long FromTime { get; set; }
        public long ToTime { get; set; }
    }
}
