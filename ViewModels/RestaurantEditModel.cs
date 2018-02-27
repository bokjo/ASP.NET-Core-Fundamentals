using System.ComponentModel.DataAnnotations;
using ASP.NET_Core_Fundamentals.Models;

namespace ASP.NET_Core_Fundamentals.ViewModels
{
    public class RestaurantEditModel
    {
        [Required, MaxLength(30)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}