using CheeseTracker.AspNetMvc.Services.Models;
using CheeseTracker.Common.DataAccess;
using System;
using System.Collections.Generic;

namespace CheeseTracker.AspNetMvc.Services
{
    public class CheeseService : ICheeseService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepository<CheeseData> cheeseDataRepository;

        public CheeseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.cheeseDataRepository = unitOfWork.CheeseDataRepository;
        }

        public void Register(Cheese cheese)
        {
            this.cheeseDataRepository.Create(
                new CheeseData
                    {
                        Name = cheese.Name,
                        Description = cheese.Description,
                        Image = cheese.Image,
                        Created = DateTime.Now
                    });

            this.unitOfWork.Save();
        }

        IEnumerable<Cheese> ICheeseService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
