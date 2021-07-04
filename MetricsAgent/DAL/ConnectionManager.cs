using MetricsAgent.DAL.Interfaces;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public class ConnectionManager : IConnectionManager
    {
        string Configartion = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public ConnectionManager()
        {
            
        }

        public SQLiteConnection CreateOpenedConnection()
        {
            return new SQLiteConnection(Configartion);
        }
    }
}
