using System.Web;

namespace CheeseTracker.AspNetMvc.App.Models
{
    public class AddCheeseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}