using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proje06_ModelBinding_Form.Models;

namespace Proje06_ModelBinding_Form.Controllers;

public class HomeController : Controller
{
   

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult YasGrubu(){  //sağ tuş addView
        return View();
    }

    [HttpPost] 
    public IActionResult YasGrubu(int yas, string ad){ //aynı isim yukarıda olduğu için hata verir.int yas yazarak overload edildi.
        if (yas==0)
        {
           ViewBag.YasGrubu="Lütfen bir yaş bilgisi giriniz" ;
        }else if (yas<18)
        {
           ViewBag.YasGrubu=$"{ad}, Reşit Değilsiniz!." ;
        }else if(yas<40)
        {
            ViewBag.YasGrubu=$"{ad} Gençsiniz!";
        }else if(yas<60)
        {
            ViewBag.YasGrubu=$"{ad} Gençlere taş çkarırsın";
        }else
        {
            ViewBag.YasGrubu=$"{ad} Hala emekli olmadınız mı?";
        }
        return View();
    }
    public IActionResult CreateProduct() //sağ tuş addView
    {
        return View();
    }


    [HttpPost]
    public IActionResult CreateProduct(Product product) //isimler formdakiye aynı!!
    {
        //Burada veritabanına kayıt işlemei yapılacak. 
        //Şimdilik biz gelen verilerin testini yapabilmek çin tekrar sayfaya yazdıralım
        // ViewBag.ResultHeader = $"{productName} adlı ürün eklendi.";
        // ViewBag.ResultBody = $"Category: {productCategory}, Price:{productPrice}";
        

        return View(product);
    }
    






















    // public IActionResult VerileriAl(string txtAd, int txtYas) //debug edip verileri görebiliriz.
    // {
    //     return View();
    // }
}
