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
     public IActionResult KitapEkle(Kitap kitap)
     {
        context.Kitaplar.Add(kitap);
        context.SaveChanges();
        return RedirectToAction("KitapEkle");
     }

     public IActionResult KategoriGüncelle(int id) //sayfayı açacağı içn httpGet
     {
        // Kategori kategori = context.Kategoriler.Where(k=>k.Id == id).FirstOrDefault();
        Kategori kategori = context.Kategoriler.Find(id);

        return View(kategori);
     }



     [HttpPost]
     public IActionResult KategoriGüncelle(Kategori kategori)
     {
      context.Kategoriler.Update(kategori);
      context.SaveChanges();
      return RedirectToAction("KategoriListesi");
     }

     public IActionResult YazarGüncelle(int id)
     {
      Yazar yazar = context.Yazarlar.Find(id);
      return View(yazar);
     }


     public IActionResult KategoriSil(int id)
     {
         Kategori kategori=context.Kategoriler.Find(id);
         return View(kategori);
     }



      [HttpPost]
     public IActionResult KategoriSil(Kategori kategori)
     {
         context.Kategoriler.Remove(kategori);
         context.SaveChanges();
         return RedirectToAction("KategoriListesi");
     }

     //Yazarlar için Silme, kitaplar için silme ve güncelleme
      public IActionResult YazarSil(int id)
     {
         Yazar yazar=context.Yazarlar.Find(id);
         return View(yazar);
     }
     
     
     [HttpPost]
     public IActionResult YazarSil(Yazar yazar)
     {
      context.Yazarlar.Remove(yazar);
      context.SaveChanges();
      return RedirectToAction("YazarListesi");

     }


       public IActionResult KitapGuncelle(int id) 
     {
        Kitap kitap = context.Kitaplar.Find(id);

        return View(kitap);
     }

     public IActionResult KitapSil(int id)
     {
         Kitap kitap=context.Kitaplar.Find(id);
         return View(kitap);
     }
     
     
     [HttpPost]
     public IActionResult KitapSil(Kitap kitap)
     {
      context.Kitaplar.Remove(kitap);
      context.SaveChanges();
      return RedirectToAction("KitaplarListesi");

     }



    



}

