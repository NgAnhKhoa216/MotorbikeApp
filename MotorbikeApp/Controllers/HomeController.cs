using Microsoft.AspNetCore.Mvc;
using MotorbikeApp.Models;
using System.Diagnostics;

namespace MotorbikeApp.Controllers
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

        public IActionResult BestSeller()
        {
            return View();
        }

        public IActionResult LatestProducts()
        {
            return View();
        }

        public IActionResult SaleOff()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Admin()
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