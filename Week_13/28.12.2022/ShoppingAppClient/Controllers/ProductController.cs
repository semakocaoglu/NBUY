using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using ShoppingAppClient.Models;

namespace ShoppingAppClient.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var urunler = new List<ProductViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5200/api/products/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    urunler = JsonConvert.DeserializeObject<List<ProductViewModel>>(apiResponse);
                }
            }
            ProductViewModel productViewModel = new ProductViewModel
            {
                Categories = kategoriler
            };
            return View(productViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                //CreateAsync adında bir HttpResponse metodu kullanacağız.

            }
            return View();
        }
        
    }
}
