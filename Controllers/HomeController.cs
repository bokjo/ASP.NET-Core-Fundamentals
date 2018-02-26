using ASP.NET_Core_Fundamentals.Models;
using ASP.NET_Core_Fundamentals.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Fundamentals.Controllers 
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
           // return Content("Hello from the Home Controller!");      

           var model =_restaurantData.GetAll();

           return View("Home", model);
        }
    }    
}