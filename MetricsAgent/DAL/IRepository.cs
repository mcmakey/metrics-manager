using System.Collections.Generic;
namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        IList<T> GetByTimePeriod(long fromTime, long toTime);

        void Create(T item);
    }
}
