using System.Web.Mvc;

namespace CheeseTracker.AspNetMvc.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}