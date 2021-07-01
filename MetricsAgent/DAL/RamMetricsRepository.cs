using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "INSERT INTO rammetrics(value, time) VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public IList<RamMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM rammetrics";

            var returnList = new List<RamMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new RamMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetInt64(1)
                    });
                }
            }

            return returnList;
        }

        public IList<RamMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM rammetrics WHERE time >= @fromTime AND time <= @toTime";
            cmd.Parameters.AddWithValue("@fromTime", fromTime);
            cmd.Parameters.AddWithValue("@toTime", toTime);
            cmd.Prepare();

            var result = new List<RamMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new RamMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetInt64(1)
                    });
                }
            }

            return result;
        }
    }
}
