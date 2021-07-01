﻿using MetricsAgent.Models;

namespace MetricsAgent.DAL.Interfaces
{
    // маркировочный интерфейс
    // необходим, чтобы проверить работу репозитория на тесте-заглушке
    public interface INetworkMetricsRepository : IRepository<NetworkMetric>
    {

    }
}
