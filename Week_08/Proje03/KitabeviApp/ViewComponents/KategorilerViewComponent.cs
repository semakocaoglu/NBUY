using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KitabeviApp.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        KitabeviContext context =new KitabeviContext();
        public IViewComponentResult InVoke()

        {
            if(RouteData.Values["id"] != null)   
            {
                ViewBag.SeciliKategori =int.Parse( RouteData.Values["id"].ToString());//Seçili kategoriyi döndürmek  için yapıldı
            }
           
            return View(context.Kategoriler.ToList());
        }
    }
}