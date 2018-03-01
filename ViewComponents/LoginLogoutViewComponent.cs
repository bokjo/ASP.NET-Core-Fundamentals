
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Fundamentals.ViewComponents
{
    [ViewComponent(Name = "LoginLogout")]
    public class LoginLogoutViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}