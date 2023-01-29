using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Core;
using EducationApp.Entity.Concrete.Identity;
using EducationApp.Entity.Concrete;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentManager;



        public StudentController(IStudentService studentService, ICategoryService categoryService, UserManager<User> userManager, IStudentService studentManager)
        {
            _studentService = studentService;
            _categoryService = categoryService;
            _userManager = userManager;
            _studentManager = studentManager;
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
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetSubCat();
            var StudentAddDto = new StudentAddDto
            {
                Categories = categories
            };
            return View(StudentAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentAddDto studentAddDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = studentAddDto.UserName,
                    Email = studentAddDto.Email

                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    var student = new Student
                    {

                        UserId = user.Id,
                        FirstName = studentAddDto.FirstName,
                        LastName = studentAddDto.LastName,
                        Age = studentAddDto.Age,
                        Gender = studentAddDto.Gender,
                        Url = Jobs.InitUrl(studentAddDto.FirstName + studentAddDto.LastName),
                        City = studentAddDto.City,
                        Description = "",
                        LessonPlace = studentAddDto.LessonPlace,
                        ImageUrl = Jobs.UploadImage(studentAddDto.ImageFile)


                    };

                    await _studentManager.CreateStudentAsync(student, studentAddDto.SelectedCategoryIds);
                    studentAddDto.ImageUrl = studentAddDto.ImageUrl;

                    return RedirectToAction("Index", "Student", new { area = "Admin" });

                }


            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(studentAddDto);


        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var student = await _studentService.GetStudentWithCategories(id);

            var user = await _userManager.FindByIdAsync(student.UserId);
            StudentUpdateDto studentUpdateDto = new StudentUpdateDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Gender = student.Gender,
                UserName = user.UserName,
                Email = user.Email,
                Age = student.Age,
                City = student.City,
                ImageUrl = student.ImageUrl,
                Categories = await _categoryService.GetAllAsync(),
                SelectedCategoryIds = student.StudentCategories.Select(tc => tc.CategoryId).ToArray()
            };
            return View(studentUpdateDto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(StudentUpdateDto studentUpdateDto, int[] selectedCategoryIds)
        {
            if (ModelState.IsValid)
            {
                var student = await _studentService.GetByIdAsync(studentUpdateDto.Id);
                if (student == null)
                {
                    return NotFound();
                }
                var url = Jobs.InitUrl(studentUpdateDto.FirstName);
                var imageUrl = studentUpdateDto.ImageFile != null ? Jobs.UploadImage(studentUpdateDto.ImageFile) : student.ImageUrl;
                student.FirstName = studentUpdateDto.FirstName;
                student.LastName = studentUpdateDto.LastName;
                student.Gender = studentUpdateDto.Gender;
                student.Age = studentUpdateDto.Age;
                student.City = studentUpdateDto.City;
                student.ImageUrl = imageUrl;

                student.Url = url;

                await _studentService.UpdateStudentAsync(student, selectedCategoryIds);
                return RedirectToAction("Index", "Student", new { area = "Admin" });
            }
            var categories = await _categoryService.GetAllAsync();
            studentUpdateDto.Categories = categories;

            return View(studentUpdateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) { return NotFound(); }
            _studentService.Delete(student);
            return RedirectToAction("Index", "Student", new { area = "Admin" });
        }







    }
}
