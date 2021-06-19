namespace MetricsAgent.Requests
{
    public class MetricGetByPeriodRequest
    {
        public long FromTime { get; set; }
        public long ToTime  { get; set; }
    }
}
