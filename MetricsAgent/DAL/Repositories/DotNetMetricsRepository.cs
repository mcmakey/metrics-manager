using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        private ConnectionManager _connectionManager = new ConnectionManager();

        public void Create(DotNetMetric item)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }

        public IList<DotNetMetric> GetAll()
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<DotNetMetric>("SELECT * FROM dotnetmetrics").ToList();
        }

        public IList<DotNetMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.CreateOpenedConnection();

            return connection.Query<DotNetMetric>("SELECT * FROM dotnetmetrics WHERE time >= @fromTime AND time <= @toTime",
                 new
                 {
                     fromTime = fromTime,
                     toTime = toTime
                 }).ToList();
        }
    }
}
