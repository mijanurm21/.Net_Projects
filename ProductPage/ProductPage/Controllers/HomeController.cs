using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductPage.Models;

namespace ProductPage.Controllers
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

        public IActionResult Product()
        {
            List<Product> products = new List<Product>() {
                new Product {Id = 1, Name = "Shoes", Description = "Description 1", Price = 1000, Image = "~/Images/Shoes.webp"},
                 new Product {Id = 2, Name = "Glasses", Description = "Description 2", Price = 2000, Image = "~/Images/Glasses.webp"},
                  new Product {Id = 3, Name = "Watch", Description = "Description 3", Price = 3000, Image = "~/Images/Watch.webp"}
            };
            return View(products);
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
