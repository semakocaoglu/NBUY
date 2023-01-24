using EducationApp.Business.Abstract;
using EducationApp.Entity.Concrete;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationApp.Core;
using EducationApp.Business.Concrete;
using EducationApp.Entity.Concrete.Identity;
using EducationApp.Web.Models;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]

    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<User> _userManager;
        private readonly ITeacherService _teacherManager;



        public TeacherController(UserManager<User> userManager, ITeacherService teacherService , ICategoryService categoryService , ITeacherService teacherManager)
        {
            _teacherService = teacherService;
            _categoryService = categoryService;
            _userManager = userManager;
            _teacherManager = teacherManager;
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

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetSubCat();
            var TeacherAddDto = new TeacherAddDto
            {
                Categories = categories
            };
            return View(TeacherAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherAddDto teacherAddDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = teacherAddDto.UserName,
                    Email = teacherAddDto.Email

                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    var teacher = new Teacher
                    {

                        UserId = user.Id,
                        FirstName = teacherAddDto.FirstName,
                        LastName = teacherAddDto.LastName,
                        Age = teacherAddDto.Age,
                        Gender = teacherAddDto.Gender,
                        Url = Jobs.InitUrl(teacherAddDto.FirstName + teacherAddDto.LastName),
                        City = teacherAddDto.City,
                        EducationStatus = "",
                        Experience = "",
                        Price = 0,
                        Description = "",
                        LessonPlace = "",
                        ImageUrl = Jobs.UploadImage(teacherAddDto.ImageFile)


                    };

                    await _teacherManager.CreateTeacherAsync(teacher, teacherAddDto.SelectedCategoryIds);
                    teacherAddDto.ImageUrl = teacherAddDto.ImageUrl;

                    return RedirectToAction("Index" , "Teacher" , new {area = "Admin" } );

                }
               
                
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(teacherAddDto);


        }










    }






}