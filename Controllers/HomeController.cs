using DonateKartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DonateKartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static string _address = "https://v6.exchangerate-api.com/v6/ae5293a7f12ad37d627fa56d/latest/";
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

        [HttpGet]
        public async Task<IEnumerable<string>> GetExchangeRate(string currency)
        {
            var result = await GetExchangeRateAsync(currency);
            return new string[] { result };
        }

        private async Task<string> GetExchangeRateAsync(string currency)
        {
            string exchangerate="";
            StringBuilder address = new StringBuilder(_address);
            address = address.Append(currency);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = await client.GetAsync(address.ToString());
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var x = JObject.Parse(result);
            var rates = x["conversion_rates"].ToArray();
            foreach (var item in rates)
            {
                var y = item.ToString();
                var array=y.Split(':').ToArray();
                var currencyvalue = array[0];
                if (currency=="USD")
                {
                    if(string.Compare(currencyvalue, "\"INR\"")==0)
                    {
                        exchangerate = array[1];
                    }
                }
                if (currency=="INR")
                {
                    if (string.Compare(array[0], "\"USD\"") == 0)
                    {
                        exchangerate = array[1];
                    }
                }


            }

            return exchangerate;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
