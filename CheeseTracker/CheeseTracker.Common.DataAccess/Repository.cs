using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace CheeseTracker.Common.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataClassesDataContext dataClassesContext;

        public Repository(DataClassesDataContext dataClassesContext)
        {
            this.dataClassesContext = dataClassesContext;
        }

        public void Create(T entity)
        {
            this.GetTable().InsertOnSubmit(entity);
        }

        public void Delete(T entity)
        {
            this.GetTable().DeleteOnSubmit(entity);
        }

        public T Get(int id)
        {
            return this.GetTable().First();
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetTable();
        }

        public void Update(T entity)
        {
            this.GetTable().Attach(entity);
            this.dataClassesContext.Refresh(RefreshMode.KeepChanges, entity);
        }

        private Table<T> GetTable()
        {
            return this.dataClassesContext.GetTable<T>();
        }
    }
}
