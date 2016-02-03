using CheeseTracker.AspNetMvc.App.Controllers;
using CheeseTracker.AspNetMvc.Services;
using FakeItEasy;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios
{
    public abstract class CheesesControllerScenarioBase : ScenarioBase
    {
        protected CheesesController Sut { get; set; }

        protected ICheeseService CheeseService { get; set; }

        protected override void Arrange()
        {
            base.Arrange();

            this.CheeseService = A.Fake<ICheeseService>();

            this.Sut = new CheesesController(this.CheeseService);
        }
    }
}
