using System.Collections.Generic;

namespace CheeseTracker.Common.DataAccess
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        T Get(int id);

        IEnumerable<T> GetAll();

        void Update(T entity);

        void Delete(T entity);
    }
}
