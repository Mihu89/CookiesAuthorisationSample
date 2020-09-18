using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CookiesAuthorisationSample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CookiesAuthorisationSample.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin([Bind] Users userModel)
        {
            var user = new Users().GetUsers()
                .Where(u => u.UserName == userModel.UserName && u.Password == userModel.Password)
                .SingleOrDefault();

            if (user != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("UserName", user.UserName),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View(user);


        }

        [HttpGet]
        public ActionResult UserAccessDenied()
        {
            return View();
        }
    }
}