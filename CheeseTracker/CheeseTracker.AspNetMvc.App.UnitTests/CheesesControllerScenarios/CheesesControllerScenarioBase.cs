using CheeseTracker.AspNetMvc.App.Controllers;
using CheeseTracker.AspNetMvc.Services;
using CheeseTracker.Common.Services;
using FakeItEasy;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios
{
    public abstract class CheesesControllerScenarioBase : ScenarioBase
    {
        protected CheesesController Sut { get; set; }

        protected ICheeseService CheeseService { get; set; }

        protected IImageConverterService ImageConverterService { get; set; }

        protected override void Arrange()
        {
            base.Arrange();

            this.CheeseService = A.Fake<ICheeseService>();
            this.ImageConverterService = A.Fake<IImageConverterService>();

            this.Sut = new CheesesController(this.CheeseService, this.ImageConverterService);
        }
    }
}
