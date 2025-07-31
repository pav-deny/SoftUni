using System.Diagnostics;
using _01.Numbers.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01.Numbers.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Numbers()
        {
            ViewBag.Count = 10;
            return View();
        }

        [HttpPost]
        public IActionResult Numbers(int count)
        {
            ViewBag.Count = count;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
