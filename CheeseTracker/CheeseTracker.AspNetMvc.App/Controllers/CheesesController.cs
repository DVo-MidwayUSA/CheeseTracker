using CheeseTracker.AspNetMvc.App.Models;
using CheeseTracker.AspNetMvc.Services;
using CheeseTracker.AspNetMvc.Services.Models;
using CheeseTracker.Common.Services;
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

        public ActionResult Index()
        {
            return View();
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
                        Image = this.imageConverterService.Convert(viewModel.Image.InputStream)
                    });

            this.TempData["SuccessMessage"] = @"Yay! Your cheese is legit!";

            return RedirectToAction("AddCheese");
        }
    }
}