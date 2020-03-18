using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Models;
using StoreManager.Repository;

namespace StoreManager.Controllers
{
    public class LoginController : Controller
    {
        private iUserRepository usersRepo;

        public LoginController(iUserRepository _usersRepo)
        {
            this.usersRepo = _usersRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Users user)
        {
            if (!string.IsNullOrEmpty(user.userName) && string.IsNullOrEmpty(user.userPassword))
            {
                return RedirectToAction("Login");
            }

            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            string Direct = "Index";
            Boolean temp = usersRepo.CheckLogin(user.userName, user.userPassword);
            if (temp == true)
            {
                if ((user.userName == "admin"))
                {
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.userName),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticated = true;
                    Direct = "Setting";
                }
                else
                {
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.userName),
                    new Claim(ClaimTypes.Role, "User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                    Direct = "Index";
                }
                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction(Direct, "Home");
                }
                return View();
            }
            else
            {
                ViewBag.Message = "Username or Password are not correct, please fill againts";
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users user)
        {
            return View();
        }
    }
}