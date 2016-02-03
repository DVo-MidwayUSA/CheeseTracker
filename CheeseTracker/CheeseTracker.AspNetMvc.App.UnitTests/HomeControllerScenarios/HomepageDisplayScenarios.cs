using CheeseTracker.AspNetMvc.App.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests.HomeControllerScenarios
{
    [TestClass]
    public class HomepageDisplayScenarios : ScenarioBase
    {
        private HomeController sut;

        protected override void Arrange()
        {
            base.Arrange();
            this.sut = new HomeController();
        }

        [TestMethod]
        public void ShouldReturnTheIndexView()
        {
            this.ActionResult = this.sut.Index();
            ((ViewResult)this.ActionResult).ViewName.ShouldEqual("Index");
        }
    }
}
