using ASP.NET_Core_Fundamentals.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Fundamentals.Pages
{
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;
        public string UrlParamName;

        public string CurrentGreeting { get; set; }
        public GreetingModel(IGreeter greeter)
        {
            _greeter = greeter;    
        }
        public void OnGet(string name)
        {
            UrlParamName = name;
            CurrentGreeting = $"{name}: {_greeter.GetMessageOfTheDay()}";
        }
    }
}