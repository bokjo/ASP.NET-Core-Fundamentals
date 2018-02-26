using System.Collections.Generic;
using ASP.NET_Core_Fundamentals.Models;

namespace ASP.NET_Core_Fundamentals.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}