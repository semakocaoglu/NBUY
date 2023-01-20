using EducationApp.Business.Abstract;
using EducationApp.Core;
using EducationApp.Entity.Concrete;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]

    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICategoryService _categoryService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public TeacherController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetAllAsync();
            var teacherListDto = new TeacherListDto
            {
                Teachers = teachers
            };

            ViewBag.Title = "Öğretmenler";
            return View(teacherListDto);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            var teacherAddDto = new TeacherAddDto
            {
                Categories = categories
            };
            return View(teacherAddDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TeacherAddDto teacherAddDto)
        {
            if (ModelState.IsValid)
            {
                var url = Jobs.InitUrl(teacherAddDto.FirstName);
                var teacher = new Teacher
                {
                    FirstName = teacherAddDto.FirstName,
                    LastName = teacherAddDto.LastName,
                    Price = teacherAddDto.Price,
                    Description = teacherAddDto.Description,
                    Gender = teacherAddDto.Gender,  
                    Age = teacherAddDto.Age,
                    Url = url,
                    Experience= teacherAddDto.Experience,
                    LessonPlace= teacherAddDto.LessonPlace,
                    EducationStatus= teacherAddDto.EducationStatus,
                    City= teacherAddDto.City,
                    ImageUrl = Jobs.UploadImage(teacherAddDto.ImageFile)
                    
                };
                await _teacherService.CreateTeacherAsync(teacher, teacherAddDto.SelectedCategoryIds);
                return RedirectToAction("Index");
            }
            var categories = await _categoryService.GetAllAsync();
            teacherAddDto.Categories = categories;
            teacherAddDto.ImageUrl = teacherAddDto.ImageUrl;
            return View(teacherAddDto);
        }









    }






}