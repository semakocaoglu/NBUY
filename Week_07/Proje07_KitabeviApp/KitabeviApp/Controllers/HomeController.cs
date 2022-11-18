using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KitabeviApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KitabeviApp.Controllers;

public class HomeController : Controller
{
    KitabeviContext context = new KitabeviContext();
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult KategoriListesi()
    {
        var kategoriler = context.Kategoriler.ToList();
        return View(kategoriler);
    }
    public IActionResult YazarListesi()
    {
        var yazarlar = context.Yazarlar.ToList();
        return View(yazarlar);
    }
    public IActionResult KitapListesi(int? id = null)
    {
        List<Kitap>kitaplar =null;
        if(id==null)
        {

       
         kitaplar = context
            .Kitaplar
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();
        

         }
         else
         {

            kitaplar = context
            .Kitaplar
            .Where(c=> c.KategoriId == id)
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();

         }
         return View(kitaplar);

         
    }
    public IActionResult Detay(int id) //return yapılmazsa hata verir.
     {
        var kitap = context
        .Kitaplar
            .Where(k => k.Id == id)
            .Include(k => k.Yazar)
            .Include(k => k.Kategori)
            .FirstOrDefault();
        return View(kitap); //sağ tuş -addview
     }

    

     public IActionResult Get(int id, string ad)   //id'nin int olmasna gerek olmadığı anlaşılması için
                                                    //MWüde link verdik
     {

        return View();
     }

    [HttpPost]
    public IActionResult KategoriEkle(Kategori kategori)
     {
        context.Kategoriler.Add(kategori); //add ile kategoriye eklenir sadece
        context.SaveChanges(); // kaydedersek veritabanına eklenir
        return RedirectToAction("KategoriListesi"); //kategoriListesi Action'ı çağırıp kategori listesini açar
     }


     public IActionResult KategoriEkle()
     {
        return View();
     }


     public IActionResult YazarEkle()
     {
        return View();
     }
     public IActionResult KitapEkle()
     {
      return View();
     }
}



