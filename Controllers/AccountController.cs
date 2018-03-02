using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Fundamentals.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var redirectUrl = Url.Action("Index", "Home");
            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme
            );
        }

        public IActionResult Logout()
        {
            var callbackUrl = Url.Page("/Account/SignedOut");
            return SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme
            );
        }



    }
}
