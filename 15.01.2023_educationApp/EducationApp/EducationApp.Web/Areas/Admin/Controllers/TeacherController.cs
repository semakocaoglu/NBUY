using EducationApp.Business.Abstract;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}
