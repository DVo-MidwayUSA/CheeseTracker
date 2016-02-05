using System.Data.Linq;

namespace CheeseTracker.AspNetMvc.Services.Models
{
    public class Cheese
    {
        public string Name { get; set; }

        public Binary Image { get; set; }

        public string Description { get; set; }
        public int Id { get; set; }
    }
}
