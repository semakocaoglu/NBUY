
using System.Collections.Generic;
using System.Diagnostics;
using KitabeviApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace KitabeviApp.Controllers
{
    
    public class KitabeviController : Controller
    {


        public IActionResult Index()
        {
            KitabeviDbContext context= new KitabeviDbContext();
            List<Kategori> kategoriler=context.Kategoriler.ToList();
            return View(kategoriler);
            return View();
        }

        
    }
}   