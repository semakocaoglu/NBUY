using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;
using ShoppingApp.Web.EmailServices.Abstract;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!");
                    return View(loginDto);
                }
                //Bu noktada email onayı yapılıp yapılmadığını kontrol edeceğiz.
                //Eğer email onaylı ise login yaptıracağız, değil ise hatırlatacağız.
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Hesabınız onaylanmamş. Lütfen mailinize gelen onay linkine tıklayarak, hesabınızı onaylayınız", "warning");
                    return View(loginDto);

                    //ÖDEV: Eğer hesap onaylı değilse burada kullancıya "Onay linki gönder" şeklinde bir buton gözüksün. Ve bu butona basıldığında tekrar onay maili gönderilsin.Normalde gözükmeyen şartlı bir buton olsun, tıklandığnda yeni bir form açılsın mail adresi istesin. TokenCode ile  (forgot email gibi)
                }



                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
                if (result.Succeeded)
                {
                    return Redirect(loginDto.ReturnUrl ?? "~/");
                }
                ModelState.AddModelError("", "Email adresi ya da parola hatalı!");
            }
            return View(loginDto);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]//İlgili cookienin sadece ait olduğu tarayıcı tarafından gönderilmesi halinde geçerli olmasını sağlar.
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    //Generate token(mail onayı için)
                    var tokenCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = tokenCode
                    });

                    //Mailin gönderilme, onaylanma vs
                    await _emailSender.SendEmailAsync(user.Email, "ShoppingApp Hesap Onaylama", $"<h1>Merhaba</h1>" +
                        $"<br>" +
                        $"<p>Lütfen hesabınızı onaylamak için aşağıdaki linke tıklayınız.</p>" +
                        $"<a href='https://localhost:7215{url}'>Onay Linki</a>");
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Lütfen mail hesabınızı kontrol edin. Gelen linki tıklayarak hesabınızı onaylayn", "warning");
                    return RedirectToAction("Login", "Account");
                }
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(registerDto);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                ViewBag.Message("Geçersiz token ya da user bilgisi!");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    ViewBag.Message("Hesabınız başarıyla onaylandı.");
                    return View();
                }
            }
            ViewBag.Message("Bir sorun oluştu ve hesabınız onaylanmadı. Tekrar deneyiniz.");
            return View();
        }
        public async Task<IActionResult> ForgotPassword()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "Lütfen mail adresinizi eksiksiz bir şekilde giriniz", "danger");
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "Böyle kayırlı bir email adresi bulunamadı.Lütfen kontrol ederek, yeniden deneyiniz", "danger");

            }
            var tokenCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = tokenCode
            });
            await _emailSender.SendEmailAsync(
                email,
                "ShoppingApp Şifre Sıfırlama Linki",
                $"Lütfen parolanızı yenilemek için <a href='https://localhost:7215{url}'>tıklayınız.</a>"

                );
            TempData["Message"] = Jobs.CreateMessage("Bilgi", "Şifre sıfırlama linkiniz, mail adresinize gönderilmiştir. Lütfen mail adresinizi kontrol ediniz", "warning");
            return RedirectToAction("Login", "Account");
            return View();
        }


        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "Bir sorun oluştu, Lütfen daha sonra tekrar deneyiniz.", "warning");
                return RedirectToAction("Login", "Account");

            }
            var resetPasswordDto = new ResetPasswordDto
            {
                Token = token
            };
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordDto);
            }
            var user = await _userManager.FindByEmailAsync
                (resetPasswordDto.Email);
            if (user == null)
            {

                TempData["Message"] = Jobs.CreateMessage("Hata", "Böyle bir kullanc bulunamadı.Tekrar Deneyiniz", "warning");
                return View("resetPasswordDto");

            }
            var result = await _userManager.ResetPasswordAsync
                (user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (result.Succeeded)
            {

                TempData["Message"] = Jobs.CreateMessage("BAşarlı", "Şifreniz başarıyla değiştirilmiştir", "success");
                return RedirectToAction("Login", "Account");

            }
            TempData["Message"] = Jobs.CreateMessage("Hata", "Bir sorun oluştu. Lütfen admin ile iletişime geçiniz", "danger");
            return Redirect("Index");


        }

    }
}

