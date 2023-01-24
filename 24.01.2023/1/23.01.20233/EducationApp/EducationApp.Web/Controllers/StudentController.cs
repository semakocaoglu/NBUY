using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Data.Concrete.EfCore.Contexts;
using EducationApp.Entity.Concrete;
using EducationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentManager;
        private readonly ICategoryService _categoryManager;

        public StudentController(IStudentService studentManager, ICategoryService categoryManager)
        {
            _studentManager = studentManager;
            _categoryManager = categoryManager;
        }


        public async Task<IActionResult> Index(string categoryurl)
        {
            List<Student> students = await _studentManager.GetStudentsByCategoryAsync(categoryurl);
            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (var student in students)
            {
                List<Category> categories = await _categoryManager.GetCategoriesByStudent(student);
                studentDtos.Add(new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Gender = student.Gender,
                    ImageUrl = student.ImageUrl,
                    Url = student.Url,
                    City = student.City,
                    Description = student.Description,
                    LessonPlace = student.LessonPlace,
                    Categories = categories


                });

            }
            return View(studentDtos);

        }


    }
}
