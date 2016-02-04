using CheeseTracker.AspNetMvc.Services.Models;
using CheeseTracker.Common.DataAccess;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace CheeseTracker.AspNetMvc.Services.UnitTests.CheeseServiceScenarios
{
    [TestClass]
    public class RegisterScenarios : CheeseServiceScenarioBase
    {
        private Cheese model;

        protected override void Arrange()
        {
            base.Arrange();
            this.model = new Cheese { Name = "Name", Description = "Description", Image = new byte[0] };
        }

        private void Act()
        {
            this.Sut.Register(this.model);
        }

        [TestMethod]
        public void ShouldCallCreateOnCheeseDataRepositoryWithMappedCheeseData()
        {
            this.Act();

            Expression<Func<CheeseData, bool>> expected = x =>
                x.Name == this.model.Name &&
                x.Description == this.model.Description &&
                x.Image == this.model.Image &&
                x.Created != null;

            A.CallTo(() => this.CheeseDataRepository.Create(A<CheeseData>.That.Matches(expected))).MustHaveHappened();
        }

        [TestMethod]
        public void ShouldCallSaveOnUnitOfWork()
        {
            this.Act();
            A.CallTo(() => this.UnitOfWork.Save()).MustHaveHappened();
        }
    }
}
