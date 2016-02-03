using CheeseTracker.AspNetMvc.App.Models;
using CheeseTracker.AspNetMvc.Services.Models;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios
{
    [TestClass]
    public class AddingANewCheesePostScenarios : CheesesControllerScenarioBase
    {
        private void Act()
        {
            this.ActionResult = this.Sut.AddCheese(A<AddCheeseViewModel>._);
        }

        [TestMethod]
        public void ShouldRedirectToTheAddCheeseView()
        {
            this.Act();
            ((RedirectToRouteResult)this.ActionResult).RouteValues["action"].ShouldEqual("AddCheese");
        }

        [TestMethod]
        public void ShouldAddSuccessMessageThroughTempData()
        {
            this.Act();
            this.Sut.TempData["SuccessMessage"].ShouldEqual("Yay! Your cheese is legit!");
        }

        [TestMethod]
        public void ShouldCallCheeseServiceToRegisterCheese()
        {
            this.Act();
            A.CallTo(() => this.CheeseService.Register(A<Cheese>._)).MustHaveHappened();
        }
    }
}
