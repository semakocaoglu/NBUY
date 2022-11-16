using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Proje04_MVC.Controllers;
public class Product{
    public int  Id { get; set; }
    public int  Name { get; set; }
    public int  Price { get; set; }
}

public class HomeController : Controller
{



    public IActionResult Index()
    {
        string ad = "Engin";
        ViewBag.KisiAd=ad;
    string dil="tr";
    string selamlama;
    if( dil=="tr")
    {
        selamlama="Hoşgeldiniz";

+    {
        selamlama="Welcome";

    }else
    {
        selamlama="";
    }
        return View();
    }

    public IActionResult About();
    {
        return View();
    }

    public IActionResult GetProducts()
    {
        List<Product>products=new List<Product>(){
            new Product(){Id=1, Name="Iphone 13", Price=24000},
            new Product(){Id=2, Name="Iphone 14", Price=24000},
            new Product(){Id=3, Name="Iphone 15", Price=24000},
            new Product(){Id=4, Name="Iphone 16", Price=24000},
            new Product(){Id=5, Name="Iphone 17", Price=24000}
        };
        // ViewBag.Products=products;
        return View(products);


    }

    public IActionResult GetCategories()
        List<Category>categories=new List<Category>(){
            new Category(){Id=1, Name="Phone"},
            new Category(){Id=2, Name="Computer"},
            new Category(){Id=3, Name="Electronic"},


        }


    
}
