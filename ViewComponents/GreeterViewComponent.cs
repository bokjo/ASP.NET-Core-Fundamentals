using ASP.NET_Core_Fundamentals.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Fundamentals.ViewComponents
{
    [ViewComponent(Name = "Greeter")]
    public class GreeterViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessageOfTheDay();
            return View("Default", model);
        }

    }
}