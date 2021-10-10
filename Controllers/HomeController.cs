using DonateKartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DonateKartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public string GetProduct(string productname)
        {
            List<ProductModel> productModel = new List<ProductModel>();
            productModel.Add(new ProductModel { ProductName = "shoes", ProductImage = "", ProductPrice = 2000 });
            productModel.Add(new ProductModel { ProductName = "bat", ProductImage = "", ProductPrice = 5000 });
            productModel.Add(new ProductModel { ProductName = "ball", ProductImage = "", ProductPrice = 600 });
            var price = productModel.Where(x=>x.ProductName.ToLower().Equals(productname.ToLower())).Select(x=>x.ProductPrice).FirstOrDefault();

            
            return price.ToString();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
