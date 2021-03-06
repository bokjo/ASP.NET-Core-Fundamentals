using ASP.NET_Core_Fundamentals.Models;
using ASP.NET_Core_Fundamentals.Services;
using ASP.NET_Core_Fundamentals.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Fundamentals.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeting;

        public HomeController(IRestaurantData restaurantData, IGreeter greeting)
        {
            _restaurantData = restaurantData;
            _greeting = greeting;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {    
            // var model = _restaurantData.GetAll();
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeting.GetMessageOfTheDay();

            return View("Home", model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.GetRestaurant(id);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Details", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.AddRestaurant(newRestaurant);

                // return View("Details", newRestaurant);
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }

    }
}