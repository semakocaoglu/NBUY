using System.Diagnostics;
using EducationApp.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace EducationApp.Web.Controllers;

public class HomeController : Controller
{

    public async Task<IActionResult> Index()
    {
        return View();

    }


}
