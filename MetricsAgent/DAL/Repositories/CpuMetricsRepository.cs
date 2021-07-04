using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private ConnectionManager _connectionManager = new ConnectionManager();

        public void Create(CpuMetric item)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }

        public IList<CpuMetric> GetAll()
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<CpuMetric>("SELECT * FROM cpumetrics").ToList();
        }

        public IList<CpuMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE time >= @fromTime AND time <= @toTime",
                new
                {
                    fromTime = fromTime,
                    toTime = toTime
                }).ToList();
        }
    }
}
