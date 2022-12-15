using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Business.Concrete;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.EmailServices.Abstract;
using ShoppingApp.Web.EmailServices.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //mvc olmasýný saðlar

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlite("Data Source=ShoppingApp.db"));
builder.Services.AddDbContext<ShopAppContext>(); //contexti eklememizi saðlar

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders(); //Cookieler içiin yapýldý (Token)

builder.Services.Configure<IdentityOptions>(options =>
{
    #region PasswordSettings
    options.Password.RequireDigit = true; //Þifre içinde mutlaka rakam bulunsun.
    options.Password.RequireLowercase = true; //Þifre içinde küçük harf bulunsun.
    options.Password.RequireUppercase = true; //Þifre içinde büyük harf bulunsun.
    options.Password.RequiredLength = 6; //Þifrre en az 6 karakter olsun
    options.Password.RequireNonAlphanumeric = true; //Þifre içinde alfanumerik karakterler bulunmasý zorunlu olsun.(.,/*)
    #endregion

    #region LoginSettings
    options.Lockout.MaxFailedAccessAttempts = 5; //Baþarýsýz giriþ deneme sayýsý en fazla 5 olsun. Fazlasýnda hesap kilitlensin.
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5); //Kilitlenmiþ hesabýn , tekrar giriþ için beklemesi gereken zaman

    #endregion

    #region UserSettings
      options.User.RequireUniqueEmail = true;//Benzersiz email adresi ile kayýt olunabilir, ayný email ile birden fazla kayýt yapýlamaz.

    #endregion

    #region SignInSetting
    options.SignIn.RequireConfirmedEmail = false; //True ise email onayý aktiftir.
    options.SignIn.RequireConfirmedPhoneNumber = false; //true ise telefon numarasý onayý aktiftir.
    #endregion

});

builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath = "/account/login";//Eðer açýlabilmesi için login olmanýn zorunlu olfuðu sayfadan istekte bulunulursa kullanýcýnýn yönlendirileceði sayfa burasý olacak. (account controllerýndaki login action metodu    
    options.LogoutPath= "/account/logout"; //Kullanýcý çýkýþ yaptýðýnda yönlendirilecek sayfa
    options.AccessDeniedPath = "/account/accessdenied"; //Yetkisiz giriþ srasýnda yönlendirilecek sayfa
    options.SlidingExpiration = true; //Varsayýlan cookie yaþam süresinin(20dk) ya da ayarlanan aþam süresinin her yeni istek sýrasýnda sýfýrlanarak yeniden baþlamasýn saðlamak
    options.ExpireTimeSpan= TimeSpan.FromMinutes(5); //yaþam süresini ayarlar.
    options.Cookie = new CookieBuilder
    {
        HttpOnly= true,
        Name=".ShoppingApp.Security.Cookie" ,
        SameSite = SameSiteMode.Strict //Güvnelik amacýyla yapýlr.
    };
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();


builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender(
    "smtp.office365.com", 587, true , "wissen_core@hotmail.com", "Wissen123." //hotmail için gereken bilgiler
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "products",
    pattern: "kategori/{categoryurl?}",
    defaults: new { controller = "Shop", action = "ProductList" }
    );

app.MapControllerRoute(
    name:"productdetails",
    pattern:"urunler/{producturl}",
    defaults: new {controller="Shop", action="ProductDetails"}
    );


app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"); ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
