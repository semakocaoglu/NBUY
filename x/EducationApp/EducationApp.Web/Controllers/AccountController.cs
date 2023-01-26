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
        private readonly ITeacherService _teacherService;



        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITeacherService teacherManager, ICategoryService categoryService, IStudentService studentManager, ITeacherService teacherService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherManager = teacherManager;
            _categoryService = categoryService;
            _studentManager = studentManager;
            _teacherService = teacherService;

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
            var name = id;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var user = await _userManager.FindByNameAsync(name);
            if (user == null) { return NotFound(); }

            List<Teacher> teachers = await _teacherManager.GetAllAsync();
            List<Student> students = await _studentManager.GetAllAsync();




            foreach (var teacher in teachers)
            {
                if (teacher.UserId == user.Id)
                {
                    #region gender
                    List<SelectListItem> genderList = new List<SelectListItem>();
                    genderList.Add(new SelectListItem
                    {
                        Text = "Kadın",
                        Value = "Kadın",
                        Selected = teacher.Gender == "Kadın" ? true : false
                    });
                    genderList.Add(new SelectListItem
                    {
                        Text = "Erkek",
                        Value = "Erkek",
                        Selected = teacher.Gender == "Erkek" ? true : false
                    });

                    #endregion

                    #region LessonPlace
                    List<SelectListItem> lessonPlaceList = new List<SelectListItem>();
                    lessonPlaceList.Add(new SelectListItem
                    {
                        Text = "Online",
                        Value = "Online",
                        Selected = teacher.LessonPlace == "Online" ? true : false
                    });
                    lessonPlaceList.Add(new SelectListItem
                    {
                        Text = "Yüz Yüze",
                        Value = "Yüz Yüze",
                        Selected = teacher.LessonPlace == "Yüz Yüze" ? true : false
                    });

                    #endregion


                    #region ExperienceList
                    List<SelectListItem> experienceList = new List<SelectListItem>();
                    experienceList.Add(new SelectListItem
                    {
                        Text = "1-3 Yıl Tecrübeli",
                        Value = "1-3 Yıl Tecrübeli",
                        Selected = teacher.Experience == "1-3 Yıl Tecrübeli" ? true : false
                    });
                    experienceList.Add(new SelectListItem
                    {
                        Text = "3-5 Yıl Tecrübeli",
                        Value = "3-5 Yıl Tecrübeli",
                        Selected = teacher.Experience == "3-5 Yıl Tecrübeli" ? true : false


                    });
                    experienceList.Add(new SelectListItem
                    {
                        Text = "5-10 Yıl Tecrübeli",
                        Value = "5-10 Yıl Tecrübeli",
                        Selected = teacher.Experience == "5-10 Yıl Tecrübeli" ? true : false


                    });
                    experienceList.Add(new SelectListItem
                    {
                        Text = "10+ Yıl Tecrübeli",
                        Value = "10+ Yıl Tecrübeli",
                        Selected = teacher.Experience == "10+ Yıl Tecrübeli" ? true : false


                    });
                    #endregion

                    var teacherswith = await _teacherManager.GetTeacherWithCategories(teacher.Id);

                    UserManageDto userManageDto = new UserManageDto
                    {

                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName,
                        Gender = teacher.Gender,
                        ImageUrl = teacher.ImageUrl,
                        Price = teacher.Price,
                        City = teacher.City,
                        UserName = user.UserName,
                        Email = user.Email,
                        Description = teacher.Description,
                        LessonPlace = teacher.LessonPlace,
                        GenderList = genderList,
                        LessonPlaceList = lessonPlaceList,
                        Experience = teacher.Experience,
                        
                        Categories = await _categoryService.GetSubCat(),

                        SelectedCategoryIds = teacher.TeacherCategories.Select(tc => tc.CategoryId).ToArray(),
                        
                        Role = "teacher"

                    };
                    ViewBag.Role = "teacher";
                    return View(userManageDto);
                }

            }
            foreach (var student in students)
            {
                if (student.UserId == user.Id)
                {
                    #region gender
                    List<SelectListItem> genderList = new List<SelectListItem>();
                    genderList.Add(new SelectListItem
                    {
                        Text = "Kadın",
                        Value = "Kadın",
                        Selected = student.Gender == "Kadın" ? true : false
                    });
                    genderList.Add(new SelectListItem
                    {
                        Text = "Erkek",
                        Value = "Erkek",
                        Selected = student.Gender == "Erkek" ? true : false
                    });

                    #endregion

                    #region LessonPlace
                    List<SelectListItem> lessonPlaceList = new List<SelectListItem>();
                    lessonPlaceList.Add(new SelectListItem
                    {
                        Text = "Online",
                        Value = "Online",
                        Selected = student.LessonPlace == "Online" ? true : false
                    });
                    lessonPlaceList.Add(new SelectListItem
                    {
                        Text = "Yüz Yüze",
                        Value = "Yüz Yüze",
                        Selected = student.LessonPlace == "Yüz Yüze" ? true : false
                    });

                    #endregion



                    var studentwith = await _studentManager.GetStudentWithCategories(student.Id);
                    UserManageDto userManageDto = new UserManageDto
                    {

                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Gender = student.Gender,
                        UserName = user.UserName,
                        Email = user.Email,
                        Description = student.Description,
                        LessonPlace = student.LessonPlace,
                        GenderList = genderList,
                        LessonPlaceList = lessonPlaceList,
                        City = student.City,
                        SelectedCategoryIds = student.StudentCategories.Select(tc => tc.CategoryId).ToArray(),
                        Categories = await _categoryService.GetSubCat(),
                        Role = "student"



                    };
                    ViewBag.Role = "student";
                    return View(userManageDto);
                }


            }
            TempData["Message"] = Jobs.CreateMessage("Hata", "Bir hata oluştu. Lütfen admin ile iletişime geçiniz.", "danger");
            return Redirect("~/");

        }




        [HttpPost]
        public async Task<IActionResult> Manage(UserManageDto userManageDto)
        {
            List<Teacher> teachers = await _teacherManager.GetAllAsync();
            List<Student> students = await _studentManager.GetAllAsync();
            if (userManageDto == null) 
            {
                return NotFound(); 
            }
            var user = await _userManager.FindByNameAsync(userManageDto.Id);
            if (user == null)
            { 
                return NotFound(); 
            }

            if (userManageDto.Role == "teacher")
            {

                foreach (var teacher in teachers)
                {
                    if (teacher.UserId == user.Id)
                    {
                        var imageUrl = userManageDto.ImageFile != null ? Jobs.UploadImage(userManageDto.ImageFile) : teacher.ImageUrl;
                        user.UserName = userManageDto.UserName;
                        user.Email = userManageDto.Email;
                        teacher.FirstName = userManageDto.FirstName;
                        teacher.LastName = userManageDto.LastName;
                        teacher.ImageUrl = imageUrl;
                        teacher.Price = userManageDto.Price;
                        teacher.Gender = userManageDto.Gender;
                        teacher.LessonPlace = userManageDto.LessonPlace;
                        teacher.Description = userManageDto.Description;
                        teacher.City = userManageDto.City;
                        teacher.Experience = userManageDto.Experience;
                        //teacher.CategoryId = userManageDto.SelectedCategoryIds;
                        var userResult = await _userManager.UpdateAsync(user);


                        //await _teacherService.UpdateTeacherAsync(teacher, selectedCategoryIds);

                        if (userResult.Succeeded)
                        {
                            TempData["Message"] = Jobs.CreateMessage("Başarılı!", "Profiliniz başarıyla kaydedilmiştir.", "success");

                        }
                        #region gender
                        List<SelectListItem> genderList = new List<SelectListItem>();
                        genderList.Add(new SelectListItem
                        {
                            Text = "Kadın",
                            Value = "Kadın",
                            Selected = teacher.Gender == "Kadın" ? true : false
                        });
                        genderList.Add(new SelectListItem
                        {
                            Text = "Erkek",
                            Value = "Erkek",
                            Selected = teacher.Gender == "Erkek" ? true : false
                        });
                        #endregion

                        #region LessonPlace
                        List<SelectListItem> lessonPlaceList = new List<SelectListItem>();
                        lessonPlaceList.Add(new SelectListItem
                        {
                            Text = "Online",
                            Value = "Online",
                            Selected = teacher.LessonPlace == "Online" ? true : false
                        });
                        lessonPlaceList.Add(new SelectListItem
                        {
                            Text = "Yüz Yüze",
                            Value = "Yüz Yüze",
                            Selected = teacher.LessonPlace == "Yüz Yüze" ? true : false
                        });

                        #endregion



                        #region ExperienceList
                        List<SelectListItem> experienceList = new List<SelectListItem>();
                        experienceList.Add(new SelectListItem
                        {
                            Text = "1-3 Yıl Tecrübeli",
                            Value = "1-3 Yıl Tecrübeli",
                            Selected = teacher.Experience == "1-3 Yıl Tecrübeli" ? true : false
                        });
                        experienceList.Add(new SelectListItem
                        {
                            Text = "3-5 Yıl Tecrübeli",
                            Value = "3-5 Yıl Tecrübeli",
                            Selected = teacher.Experience == "3-5 Yıl Tecrübeli" ? true : false


                        });
                        experienceList.Add(new SelectListItem
                        {
                            Text = "5-10 Yıl Tecrübeli",
                            Value = "5-10 Yıl Tecrübeli",
                            Selected = teacher.Experience == "5-10 Yıl Tecrübeli" ? true : false


                        });
                        experienceList.Add(new SelectListItem
                        {
                            Text = "10+ Yıl Tecrübeli",
                            Value = "10+ Yıl Tecrübeli",
                            Selected = teacher.Experience == "10+ Yıl Tecrübeli" ? true : false


                        });
                        #endregion
                        userManageDto.GenderList = genderList;
                        userManageDto.ExperienceList = experienceList;
                        userManageDto.LessonPlaceList = lessonPlaceList;
                        return View(userManageDto);
                    }
                }
            }

            if (userManageDto.Role == "student")
            {

                foreach (var student in students)
                {
                    if (student.UserId == user.Id)
                    {
                        user.UserName = userManageDto.UserName;
                        user.Email = userManageDto.Email;
                        student.FirstName = userManageDto.FirstName;
                        student.LastName = userManageDto.LastName;
                        student.City = userManageDto.City;
                        student.Gender = userManageDto.Gender;
                        student.LessonPlace = userManageDto.LessonPlace;    
                        student.Description = userManageDto.Description;
                        student.City = userManageDto.City;
                        var userResult = await _userManager.UpdateAsync(user);

                        //await _studentManager.UpdateStudentAsync(student, selectedCategoryIds);
                        if (userResult.Succeeded)
                        {
                            TempData["Message"] = Jobs.CreateMessage("Başarılı!", "Profiliniz başarıyla kaydedilmiştir.", "success");
                            return RedirectToAction("Index", "Home");
                        }
                        #region gender
                        List<SelectListItem> genderList = new List<SelectListItem>();
                        genderList.Add(new SelectListItem
                        {
                            Text = "Kadın",
                            Value = "Kadın",
                            Selected = student.Gender == "Kadın" ? true : false
                        });
                        genderList.Add(new SelectListItem
                        {
                            Text = "Erkek",
                            Value = "Erkek",
                            Selected = student.Gender == "Erkek" ? true : false
                        });
                        #endregion

                        #region LessonPlace
                        List<SelectListItem> lessonPlaceList = new List<SelectListItem>();
                        lessonPlaceList.Add(new SelectListItem
                        {
                            Text = "Online",
                            Value = "Online",
                            Selected = student.LessonPlace == "Online" ? true : false
                        });
                        lessonPlaceList.Add(new SelectListItem
                        {
                            Text = "Yüz Yüze",
                            Value = "Yüz Yüze",
                            Selected = student.LessonPlace == "Yüz Yüze" ? true : false
                        });

                        #endregion


                        userManageDto.GenderList = genderList;
                        userManageDto.LessonPlaceList = lessonPlaceList;
                        return View(userManageDto);
                    }
                }
            }

            TempData["Message"] = Jobs.CreateMessage("Hata", "Bir hata oluştu. Lütfen admin ile iletişime geçiniz.", "danger");
            return Redirect("~/");

        }























    }
}









