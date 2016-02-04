namespace CheeseTracker.Common.DataAccess
{
    public partial class DataClassesDataContext : IUnitOfWork
    {
        public IRepository<CheeseData> CheeseDataRepository
        {
            get
            {
                return new Repository<CheeseData>(this);
            }
        }

        public void Save()
        {
            this.SubmitChanges();
        }
    }
}