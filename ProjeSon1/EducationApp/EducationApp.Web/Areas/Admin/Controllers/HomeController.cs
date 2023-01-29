using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
