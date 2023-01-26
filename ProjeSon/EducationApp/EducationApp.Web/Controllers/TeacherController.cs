using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Entity.Concrete;
using EducationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using EducationApp.Data.Concrete.EfCore.Contexts;

namespace EducationApp.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherManager;
        private readonly ICategoryService _categoryManager;

        public TeacherController(ITeacherService teacherManager, ICategoryService categoryManager)
        {
            _teacherManager = teacherManager;
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index(string categoryurl)
        {
            List<Teacher> teachers = await _teacherManager.GetTeachersByCategoryAsync(categoryurl);
            List<TeacherDto> teacherDtos = new List<TeacherDto>();
            foreach (var teacher in teachers)
            {
                List<Category> categories = await _categoryManager.GetCategoriesByTeacher(teacher);
                teacherDtos.Add(new TeacherDto
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Age = teacher.Age,
                    Gender = teacher.Gender,
                    ImageUrl = teacher.ImageUrl,
                    Url = teacher.Url,
                    City = teacher.City,
                    Description = teacher.Description,
                    LessonPlace = teacher.LessonPlace,
                    EducationStatus= teacher.EducationStatus,
                    Price= teacher.Price,
                    Experience= teacher.Experience,
                    Categories = categories


                });

            }
            return View(teacherDtos);
        }
        public async Task<IActionResult> TeacherDetails(string teacherUrl)
        {
            if (teacherUrl == null)
            {
                return NotFound();
            }
            var teacher = await _teacherManager.GetTeacherDetailsByUrlAsync(teacherUrl);
            TeacherDetailsDto teacherDetailsDto = new TeacherDetailsDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Age = teacher.Age,
                Gender = teacher.Gender,
                ImageUrl = teacher.ImageUrl,
                Url = teacher.Url,
                City = teacher.City,
                Description = teacher.Description,
                Price = teacher.Price,
              
                Categories = teacher
                    .TeacherCategories
                    .Select(tc => tc.Category)
                    .ToList()
            };

            return View(teacherDetailsDto);
        }



    }
}
