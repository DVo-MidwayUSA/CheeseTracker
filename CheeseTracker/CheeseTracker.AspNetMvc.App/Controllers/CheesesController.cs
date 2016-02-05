using CheeseTracker.AspNetMvc.App.Models;
using CheeseTracker.AspNetMvc.Services;
using CheeseTracker.AspNetMvc.Services.Models;
using CheeseTracker.Common.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.Controllers
{
    public class CheesesController : Controller
    {
        private readonly ICheeseService cheeseService;

        private readonly IImageConverterService imageConverterService;

        public CheesesController(ICheeseService cheeseService, IImageConverterService imageConverterService)
        {
            this.cheeseService = cheeseService;
            this.imageConverterService = imageConverterService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var listings = this.cheeseService.GetAll();
            var viewModel = listings.Select(x => new CheeseListingViewModel { Id = x.Id });
            return View("Index", viewModel);
        }

        [HttpGet]
        public ViewResult AddCheese()
        {
            return View("AddCheese", new AddCheeseViewModel());
        }

        [HttpPost]
        public ActionResult AddCheese(AddCheeseViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("AddCheese", viewModel);
            }

            this.cheeseService.Register(
                new Cheese
                    {
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        Image = this.imageConverterService.ConvertToBinary(viewModel.Image.InputStream)
                    });

            this.TempData["SuccessMessage"] = @"Yay! Your cheese is legit!";

            return RedirectToAction("AddCheese");
        }
    }
}