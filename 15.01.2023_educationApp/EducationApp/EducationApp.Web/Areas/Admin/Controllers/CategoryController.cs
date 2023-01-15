using EducationApp.Business.Abstract;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryListDto = new CategoryListDto
            {
                Categories = categories
            };
            ViewBag.SelectedMenu = "Category";
            ViewBag.Title = "Dersler";
            return View(categoryListDto);

        }
    }
}
