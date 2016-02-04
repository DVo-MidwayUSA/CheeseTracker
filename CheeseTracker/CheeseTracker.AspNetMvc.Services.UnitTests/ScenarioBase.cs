using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheeseTracker.AspNetMvc.Services.UnitTests
{
    public abstract class ScenarioBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            this.Arrange();
        }

        protected virtual void Arrange()
        {
        }
    }
}
