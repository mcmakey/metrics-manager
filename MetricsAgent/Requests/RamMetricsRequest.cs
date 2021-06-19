namespace MetricsAgent.Requests
{
    public class RamMetricsCreateRequest
    {
        public long Time { get; set; }
        public int Value { get; set; }
    }

    public class RamMetricsGetByPeriodRequest
    {
        public long FromTime { get; set; }
        public long ToTime { get; set; }
    }
}
