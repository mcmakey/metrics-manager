using System.Collections.Generic;

namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();

        void Create(T item);
    }
}
