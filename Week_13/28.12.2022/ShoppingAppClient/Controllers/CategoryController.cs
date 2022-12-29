using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingAppClient.Models;

namespace ShoppingAppClient.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //Api'mizden kategori listesiini getiren bir istekte bublunacak. http://localhost:5200/api/categories
            var kategoriler = new List<CategoryViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5200/api/categories/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kategoriler = JsonConvert.DeserializeObject<List<CategoryViewModel>>(apiResponse);
                }
            }
            return View(kategoriler);
        }
    }
}
