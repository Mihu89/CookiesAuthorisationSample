using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CookiesAuthorisationSample.Models;
using Microsoft.AspNetCore.Authorization;

namespace CookiesAuthorisationSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Users()
        {
            var users = new Users();
            return View(users.GetUsers());
        }

        [Authorize(Policy = "UserPolicy")]
        public ActionResult UsersPolicy()
        {
            var users = new Users();
            return View(users.GetUsers());
        }

        [Authorize(Roles = "User")]
        public ActionResult UsersRoley()
        {
            var users = new Users();
            return View("Users", users.GetUsers());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminUser()
        {
            var users = new Users();
            return View("Users", users.GetUsers());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
