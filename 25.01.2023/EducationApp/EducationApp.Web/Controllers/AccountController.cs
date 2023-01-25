using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Core;
using EducationApp.Entity.Concrete;
using EducationApp.Entity.Concrete.Identity;
using EducationApp.Web.Areas.Admin.Models.Dtos;
using EducationApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationApp.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITeacherService _teacherManager;
        private readonly ICategoryService _categoryService;
        private readonly IStudentService _studentManager;



        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITeacherService teacherManager, ICategoryService categoryService, IStudentService studentManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherManager = teacherManager;
            _categoryService = categoryService;
            _studentManager = studentManager;

        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginDto { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!");
                    return View(loginDto);
                }

                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
                if (result.Succeeded)
                {
                    return Redirect(loginDto.ReturnUrl ?? "~/");
                }
                ModelState.AddModelError("", "Email adresi ya da parola hatalı");
            }
            return View(loginDto);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RegisterTeacher()
        {

            var categories = await _categoryService.GetSubCat();
            var RegisterDto = new RegisterDto
            {
                Categories = categories
            };
            return View(RegisterDto);

        }
        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email

                };
                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    var teacher = new Teacher
                    {

                        UserId = user.Id,
                        FirstName = registerDto.FirstName,
                        LastName = registerDto.LastName,
                        Age = registerDto.Age,
                        Gender = registerDto.Gender,
                        Url = Jobs.InitUrl(registerDto.FirstName + registerDto.LastName),
                        City = registerDto.City,
                        EducationStatus = "",
                        Experience = "",
                        Price = 0,
                        ImageUrl = "",
                        Description = "",
                        LessonPlace = ""



                    };

                    await _teacherManager.CreateTeacherAsync(teacher, registerDto.SelectedCategoryIds);
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Hesabınız başarıyla oluşturulmuştur. Giriş yapabilirsiniz.", "success");

                    return RedirectToAction("Login", "Account");

                }
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(registerDto);


        }


        public async Task<IActionResult> RegisterStudent()
        {

            var categories = await _categoryService.GetSubCat();
            var RegisterDto = new RegisterDto
            {
                Categories = categories
            };
            return View(RegisterDto);

        }
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email

                };
                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");

                    var student = new Student
                    {

                        UserId = user.Id,
                        FirstName = registerDto.FirstName,
                        LastName = registerDto.LastName,
                        Age = registerDto.Age,
                        Gender = registerDto.Gender,
                        Url = Jobs.InitUrl(registerDto.FirstName + registerDto.LastName),
                        City = registerDto.City,
                        ImageUrl = "",
                        Description = "",
                        LessonPlace = ""
                    };

                    await _studentManager.CreateStudentAsync(student, registerDto.SelectedCategoryIds);
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Hesabınız başarıyla oluşturulmuştur. Giriş yapabilirsiniz.", "success");

                    return RedirectToAction("Login", "Account");

                }
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(registerDto);


        }

        public async Task<IActionResult> Manage(string id)
        {
            var userName = id;
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null) { return NotFound(); }
            
            var teacher = await _teacherManager.GetTeacherByUserId(user.Id);
            var student = await _studentManager.GetStudentByUserId(user.Id);

            var manageDto = new ManageDto
            {
                Teacher = teacher,
                Student = student,
                User = user,
                SelectedCategoryIds = teacher.TeacherCategories.Select(tc => tc.CategoryId).ToArray(),
                Categories = await _categoryService.GetSubCat()
            };

            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
            });

            return View(manageDto);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageDto ManageDto)
        {
            if (ManageDto == null) { return NotFound(); }
            var teacher = await _teacherManager.GetByIdAsync(ManageDto.Teacher.Id);

            if (teacher == null) { return NotFound(); }

            var user = await _userManager.FindByIdAsync(teacher.UserId);

            teacher.FirstName = ManageDto.Teacher.FirstName;
            teacher.LastName = ManageDto.Teacher.LastName;
            user.UserName = ManageDto.User.UserName;
            //teacher.Gender = ManageDto.Teacher.Gender;
            user.Email = ManageDto.User.Email;
            teacher.Age = ManageDto.Teacher.Age;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("Başarılı!", "Profiliniz başarıyla kaydedilmiştir.", "success");
            }
            return View(ManageDto);
        }






















    }
}









