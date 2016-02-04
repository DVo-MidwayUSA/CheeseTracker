using CheeseTracker.Common.DataAccess;
using FakeItEasy;

namespace CheeseTracker.AspNetMvc.Services.UnitTests.CheeseServiceScenarios
{
    public abstract class CheeseServiceScenarioBase : ScenarioBase
    {
        protected CheeseService Sut { get; set; }

        protected IUnitOfWork UnitOfWork { get; set; }

        protected IRepository<CheeseData> CheeseDataRepository { get; set; }

        protected override void Arrange()
        {
            base.Arrange();

            this.UnitOfWork = A.Fake<IUnitOfWork>();
            this.CheeseDataRepository = this.UnitOfWork.CheeseDataRepository;

            this.Sut = new CheeseService(this.UnitOfWork);
        }
    }
}
