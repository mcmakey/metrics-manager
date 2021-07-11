using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private ConnectionManager _connectionManager = new ConnectionManager();

        public void Create(NetworkMetric item)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            connection.Execute("INSERT INTO networkmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }

        public IList<NetworkMetric> GetAll()
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<NetworkMetric>("SELECT * FROM networkmetrics").ToList();
        }

        public IList<NetworkMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<NetworkMetric>("SELECT * FROM networkmetrics WHERE time >= @fromTime AND time <= @toTime",
                new
                {
                    fromTime = fromTime,
                    toTime = toTime
                }).ToList();
        }
    }
}
