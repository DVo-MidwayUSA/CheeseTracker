using CheeseTracker.AspNetMvc.App.Models;
using CheeseTracker.AspNetMvc.Services.Models;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios
{
    [TestClass]
    public class AddingANewCheesePostScenarios : CheesesControllerScenarioBase
    {
        private AddCheeseViewModel viewModel;

        protected override void Arrange()
        {
            base.Arrange();
            this.viewModel = new AddCheeseViewModel { Image = A.Fake<HttpPostedFileBase>() };
        }

        private void Act()
        {
            this.ActionResult = this.Sut.AddCheese(this.viewModel);
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

        [TestMethod]
        public void Test()
        {
            this.Act();
            A.CallTo(() => this.ImageConverterService.Convert(A<Stream>._)).MustHaveHappened();
        }
    }
}
