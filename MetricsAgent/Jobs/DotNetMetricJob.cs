using MetricsAgent.DAL.Interfaces;
using Quartz;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _dotnetCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository) 
        {
            _repository = repository;
            _dotnetCounter = new PerformanceCounter(".NET CLR Memory", "# Total committed Bytes", "_Global_");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var dotnetUsage = Convert.ToInt32(_dotnetCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new Models.DotNetMetric{ Time = time, Value = dotnetUsage});

            return Task.CompletedTask;
        }
    }
}
