using EducationApp.Business.Abstract;
using EducationApp.Entity.Concrete;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationApp.Core;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]

    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
     

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
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

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherAddDto teacherAddDto)
        {
            if(ModelState.IsValid)
            {
                var url = Jobs.InitUrl(teacherAddDto.FirstName);
                var teacher = new Teacher
                {
                    FirstName = teacherAddDto.FirstName,
                    LastName = teacherAddDto.LastName,
                    Age= teacherAddDto.Age,
                    City = teacherAddDto.City,
                    Experience = teacherAddDto.Experience,  
                    Description= teacherAddDto.Description,
                    Gender = teacherAddDto.Gender,  
                    LessonPlace = teacherAddDto.LessonPlace,
                    ImageUrl = Jobs.UploadImage(teacherAddDto.ImageFile),
                    Price= teacherAddDto.Price,
                    EducationStatus = teacherAddDto.EducationStatus,
                    Url = url

                };
                await _teacherService.CreateAsync(teacher);
                return RedirectToAction("Index");
            }
            return View();  
        }









    }






}