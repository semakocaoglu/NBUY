using System.Diagnostics;
using EducationApp.Business.Abstract;
using EducationApp.Entity.Concrete;
using EducationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace EducationApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryManager;

    public HomeController(ICategoryService categoryManager)
    {
        _categoryManager = categoryManager;
    }

    public async Task<IActionResult> Index()
    {
        List<Category> categories = await _categoryManager.GetHomePageCategoriesAsync();
        List<CategoryDto> categoryDtos = new List<CategoryDto>();
        foreach (var category in categories)
        {
            categoryDtos.Add(new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                //ImageUrl = category.ImageUrl,
                Url = category.Url,

            });
        }
        return View(categoryDtos);

    }


}
