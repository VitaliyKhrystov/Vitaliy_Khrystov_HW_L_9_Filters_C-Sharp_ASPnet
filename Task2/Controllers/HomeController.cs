using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Text.Json;
using Task2.Infrastructure;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string cookieKey = "CookiesData";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Profile]
        public IActionResult Index()
        {
            if (cookieKey != null && Request.Cookies.ContainsKey(cookieKey))
            {
                Person person = JsonSerializer.Deserialize<Person>(Request.Cookies[cookieKey]);
                return View(person);
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Person model)
        {
            if (ModelState.IsValid)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(cookieKey, JsonSerializer.Serialize<Person>(model), options);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Exit()
        {
            Response.Cookies.Delete(cookieKey);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Individual()
        {
            return View();
        }
    }
}