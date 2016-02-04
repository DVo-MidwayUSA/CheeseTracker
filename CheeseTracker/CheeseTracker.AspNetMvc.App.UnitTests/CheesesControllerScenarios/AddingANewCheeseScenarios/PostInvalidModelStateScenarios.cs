using CheeseTracker.AspNetMvc.App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios.AddingANewCheeseScenarios
{
    [TestClass]
    public class PostInvalidModelStateScenarios : CheesesControllerScenarioBase
    {
        private AddCheeseViewModel viewModel;

        protected override void Arrange()
        {
            base.Arrange();
            this.viewModel = new AddCheeseViewModel();
            this.Sut.ModelState.AddModelError(string.Empty, string.Empty);
        }

        private void Act()
        {
            this.ActionResult = this.Sut.AddCheese(this.viewModel);
        }

        [TestMethod]
        public void ShouldReturnView()
        {
            this.Act();
            ((ViewResult)this.ActionResult).ViewName.ShouldEqual("AddCheese");
        }

        [TestMethod]
        public void ShouldReturnPassedInViewModel()
        {
            this.Act();
            ((ViewResult)this.ActionResult).Model.ShouldBeSameAs(this.viewModel);
        }
    }
}
