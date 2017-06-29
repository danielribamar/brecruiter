using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BRecruiter.Web.Frontend.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!AuthenticationManager.LoginUser(model))
            {
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name ,"Barbara")
            };

            var userIdententity = new ClaimsIdentity(claims, "login");

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdententity);
            await HttpContext.Authentication.SignInAsync("CookieAuthentication", principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("CookieAuthentication");
            return Redirect("/Account/Login");
        }
    }
}