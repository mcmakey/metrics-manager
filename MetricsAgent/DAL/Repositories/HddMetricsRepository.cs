using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
        private ConnectionManager _connectionManager = new ConnectionManager();

        public void Create(HddMetric item)
        {
            using var connection = _connectionManager.CreateOpenedConnection();
            connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }

        public IList<HddMetric> GetAll()
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<HddMetric>("SELECT * FROM hddmetrics").ToList();
        }

        public IList<HddMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.CreateOpenedConnection();
            return connection.Query<HddMetric>("SELECT * FROM hddmetrics WHERE time >= @fromTime AND time <= @toTime",
                new
                {
                    fromTime = fromTime,
                    toTime = toTime
                }).ToList();
        }
    }
}
