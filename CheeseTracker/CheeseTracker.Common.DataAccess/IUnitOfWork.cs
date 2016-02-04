namespace CheeseTracker.Common.DataAccess
{
    public interface IUnitOfWork
    {
        IRepository<CheeseData> CheeseDataRepository { get; }

        void Save();
    }
}
