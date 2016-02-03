using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests
{
    public abstract class ScenarioBase
    {
        protected ActionResult ActionResult { get; set; }

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
