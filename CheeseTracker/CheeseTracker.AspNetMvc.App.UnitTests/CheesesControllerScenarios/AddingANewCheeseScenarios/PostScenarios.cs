using CheeseTracker.AspNetMvc.App.Models;
using CheeseTracker.AspNetMvc.Services.Models;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios.AddingANewCheeseScenarios
{
    [TestClass]
    public class PostScenarios : CheesesControllerScenarioBase
    {
        private Binary imageBinary;

        private AddCheeseViewModel viewModel;

        protected override void Arrange()
        {
            base.Arrange();

            this.imageBinary = new byte[0];

            this.viewModel = new AddCheeseViewModel
                {
                    Name = "Name",
                    Description = "Description",
                    Image = A.Fake<HttpPostedFileBase>()
                };

            A.CallTo(
                () => this.ImageConverterService
                    .ConvertToBinary(this.viewModel.Image.InputStream)).Returns(this.imageBinary);
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
        public void ShouldCallCheeseServiceToRegisterAMappedCheese()
        {
            this.Act();

            Expression<Func<Cheese, bool>> expected = x => 
                x.Name == this.viewModel.Name &&
                x.Description == this.viewModel.Description &&
                x.Image == this.imageBinary;

            A.CallTo(() => this.CheeseService.Register(A<Cheese>.That.Matches(expected))).MustHaveHappened();
        }
    }
}
