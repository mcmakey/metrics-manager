namespace MetricsManager.Requests
{
    public class GetAllHddMetricsApiRequest
    {
        public string ClientBaseAddress { get; set; }
        public long FromTime { get; set; }
        public long ToTime { get; set; }
    }
}
