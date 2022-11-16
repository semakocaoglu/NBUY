using System;      //sağ tık / controller
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proje05_MVC_EfCore.CodeFirst.Models;

namespace Proje05_MVC_EfCore.CodeFirst.Controllers
{
    
    public class ProductController : Controller
    {
     

        public IActionResult Index() //sağ tuş add view
        {
            MyDbContext context = new MyDbContext(); //ctrl+.
            List<Product> products=context.Products.ToList();
            return View(products);
        }

       
    }
}