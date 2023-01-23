using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Core;
using EducationApp.Entity.Concrete;
using EducationApp.Entity.Concrete.Identity;
using EducationApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}









