using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private ConnectionManager _connectionManager = new ConnectionManager();

        public void Create(RamMetric item)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }

        public IList<RamMetric> GetAll()
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<RamMetric>("SELECT * FROM rammetrics").ToList();
        }

        public IList<RamMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE time >= @fromTime AND time <= @toTime",
                new
                {
                    fromTime = fromTime,
                    toTime = toTime
                }).ToList();
        }
    }
}
