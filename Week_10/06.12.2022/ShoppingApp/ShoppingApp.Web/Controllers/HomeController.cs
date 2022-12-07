using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Web.Models;

namespace ShoppingApp.Web.Controllers;

public class HomeController : Controller
{
    

    public IActionResult Index()
    {
        return View();
    }

    

    
}
