using MetricsAgent.DAL.Interfaces;
using Quartz;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository) 
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", "Qualcomm Atheros AR946x Wireless Network Adapter");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var bytesReceived = Convert.ToInt32(_networkCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new Models.NetworkMetric { Time = time, Value = bytesReceived });

            return Task.CompletedTask;
        }
    }
}
