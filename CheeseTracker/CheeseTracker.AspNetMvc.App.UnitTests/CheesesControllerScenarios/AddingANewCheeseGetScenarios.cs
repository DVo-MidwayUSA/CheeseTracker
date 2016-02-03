using CheeseTracker.AspNetMvc.App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios
{
    [TestClass]
    public class AddingANewCheeseGetScenarios : CheesesControllerScenarioBase
    {
        private void Act()
        {
            this.ActionResult = this.Sut.AddCheese();
        }

        [TestMethod]
        public void ShouldReturnTheAddCheeseView()
        {
            this.Act();
            ((ViewResult)this.ActionResult).ViewName.ShouldEqual("AddCheese");
        }

        [TestMethod]
        public void ShouldReturnAnAddCheeseViewModel()
        {
            this.Act();
            ((ViewResult)this.ActionResult).Model.ShouldBeType<AddCheeseViewModel>();
        }
    }
}
