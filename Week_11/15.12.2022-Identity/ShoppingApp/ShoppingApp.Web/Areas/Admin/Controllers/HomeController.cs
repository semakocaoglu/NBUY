using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Authorize] //Bu controllerdan bir istekte bulunabilmek için mutlaka giriş yap demej
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
