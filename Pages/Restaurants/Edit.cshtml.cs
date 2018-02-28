using ASP.NET_Core_Fundamentals.Models;
using ASP.NET_Core_Fundamentals.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Fundamentals.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData _restaurantData;
        
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;   
        }
        public IActionResult OnGet(int id)
        {
            Restaurant = _restaurantData.GetRestaurant(id);

            if (Restaurant == null) 
            {
                return RedirectToAction("Index", "Home");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _restaurantData.UpdateRestaurant(Restaurant);
                return RedirectToAction("Details", "Home", new { id=Restaurant.Id });

            }

            return Page();
        }
    }
}