using CheeseTracker.AspNetMvc.Services.Models;
using System.Collections.Generic;

namespace CheeseTracker.AspNetMvc.Services
{
    public interface ICheeseService
    {
        void Register(Cheese cheese);

        IEnumerable<Cheese> GetAll();
    }
}
