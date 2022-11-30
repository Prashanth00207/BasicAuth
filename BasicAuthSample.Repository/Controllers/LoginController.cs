using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicAuthSample.Repository.Models;
using BasicAuthSample.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BasicAuthSample.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Login login)
        {
            //Save to DB in to login Table
            login.CreatedOn = DateTime.Now;
            login = LoginRepository.Register(login);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(Login login)
        {
            login = LoginRepository.IsLoginValid(login);
            if (login!=null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, login.UserName));
                foreach(UserRole UserRole in login.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, UserRole.Role.Name));
                }
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal= new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("List", "Appointment");

            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }
    }
}
