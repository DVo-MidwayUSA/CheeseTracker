using CheeseTracker.AspNetMvc.App.Models;
using CheeseTracker.AspNetMvc.Services.Models;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.UnitTests.CheesesControllerScenarios.ViewingCheesesScenarios
{
    [TestClass]
    public class GetScenarios : CheesesControllerScenarioBase
    {
        private Cheese model1;

        private Cheese model2;

        protected override void Arrange()
        {
            base.Arrange();

            this.model1 = new Cheese { Id = 1 };
            this.model2 = new Cheese { Id = 2 };

            var viewModels = new List<Cheese> { this.model1, this.model2 };

            A.CallTo(() => this.CheeseService.GetAll()).Returns(viewModels);
        }

        private void Act()
        {
            this.ActionResult = this.Sut.Index();
        }

        [TestMethod]
        public void ShouldReturnTheIndexView()
        {
            this.Act();
            ((ViewResult)this.ActionResult).ViewName.ShouldEqual("Index");
        }

        [TestMethod]
        public void ShouldReturnACollectionOfMappedCheeseListings()
        {
            this.Act();
            var viewModel = (IEnumerable<CheeseListingViewModel>)((ViewResult)this.ActionResult).Model;
            viewModel.First().Id.ShouldEqual(1);
        }

        [TestMethod]
        public void ShouldCallCheeseServiceToGetAllCheeseListings()
        {
            this.Act();
            A.CallTo(() => this.CheeseService.GetAll()).MustHaveHappened();
        }
    }
}
