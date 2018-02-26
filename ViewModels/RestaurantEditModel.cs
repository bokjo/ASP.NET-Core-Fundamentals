using ASP.NET_Core_Fundamentals.Models;

namespace ASP.NET_Core_Fundamentals.ViewModels
{
    public class RestaurantEditModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}