using System.Web;

namespace CheeseTracker.AspNetMvc.App.Models
{
    public class AddCheeseViewModel
    {
        public HttpPostedFileBase Image { get; set; }
    }
}