using EducationApp.Business.Abstract;
using EducationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace ShoppingApp.Web.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            if (RouteData.Values["categoryurl"] != null)
            {
                ViewBag.SelectedCategory = RouteData.Values["categoryurl"];
            }
            var categories = await _categoryManager.GetUpCat();
            var categoryDtos = new List<CategoryDto>();
            foreach (var upCategory in categories)
            {
                categoryDtos.Add(new CategoryDto
                {
                    Id = upCategory.Id,
                    Name = upCategory.Name,
                    Description = upCategory.Description,
                    UpCatId = upCategory.Id,
                    Url = upCategory.Url,
                    SubCategory = await _categoryManager.GetSubCat(upCategory.Id)
                });
            }
            return View(categoryDtos);
        }
        
    }
}
