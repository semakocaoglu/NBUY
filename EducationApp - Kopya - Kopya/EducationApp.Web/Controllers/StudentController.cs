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

        public StudentController(IStudentService studentManager)
        {
            _studentManager = studentManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();

        }


        public async Task<IActionResult> StudentList(string categoryurl)
        {
            List<Student> students = await _studentManager.GetStudentsByCategoryAsync(categoryurl);
            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (var student in students)
            {
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
                    Email = student.Email,
                    Phone = student.Phone,
                    Description = student.Description,
                    LessonPlace = student.LessonPlace,
                    Categories = student
                    .StudentCategories
                    .Select(sc => sc.Category)
                    .ToList()


                });

            }
            return View(studentDtos);

        }
       

    }
}
