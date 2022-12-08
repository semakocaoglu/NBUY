using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class CategoryListDto : Controller
    {
        public List<Category>Categories { get;set; }
    }
}
