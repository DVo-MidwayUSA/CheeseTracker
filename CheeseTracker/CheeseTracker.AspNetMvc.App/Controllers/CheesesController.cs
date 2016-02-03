using CheeseTracker.AspNetMvc.App.Models;
using CheeseTracker.AspNetMvc.Services;
using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.Controllers
{
    public class CheesesController : Controller
    {
        private ICheeseService cheeseService;

        public CheesesController(ICheeseService cheeseService)
        {
            this.cheeseService = cheeseService;
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
            this.cheeseService.Register(new Services.Models.Cheese());

            this.TempData["SuccessMessage"] = @"Yay! Your cheese is legit!";
            return RedirectToAction("AddCheese");
        }
    }
}