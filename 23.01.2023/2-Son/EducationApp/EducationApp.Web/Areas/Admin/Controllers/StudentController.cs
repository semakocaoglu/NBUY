using EducationApp.Business.Abstract;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async  Task<IActionResult> Index()
        {

            var students = await _studentService.GetAllStudentsWithCategory();
            var studentListDto = new StudentListDto
            {
                Students = students
            };

            ViewBag.Title = "Öğrenciler";
            return View(studentListDto);
        }
    }
}
