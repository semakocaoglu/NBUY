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

builder.Services.AddControllersWithViews(); //mvc olmas�n� sa�lar

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlite("Data Source=ShoppingApp.db"));
builder.Services.AddDbContext<ShopAppContext>(); //contexti eklememizi sa�lar

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders(); //Cookieler i�iin yap�ld� (Token)

builder.Services.Configure<IdentityOptions>(options =>
{
    #region PasswordSettings
    options.Password.RequireDigit = true; //�ifre i�inde mutlaka rakam bulunsun.
    options.Password.RequireLowercase = true; //�ifre i�inde k���k harf bulunsun.
    options.Password.RequireUppercase = true; //�ifre i�inde b�y�k harf bulunsun.
    options.Password.RequiredLength = 6; //�ifrre en az 6 karakter olsun
    options.Password.RequireNonAlphanumeric = true; //�ifre i�inde alfanumerik karakterler bulunmas� zorunlu olsun.(.,/*)
    #endregion

    #region LoginSettings
    options.Lockout.MaxFailedAccessAttempts = 5; //Ba�ar�s�z giri� deneme say�s� en fazla 5 olsun. Fazlas�nda hesap kilitlensin.
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5); //Kilitlenmi� hesab�n , tekrar giri� i�in beklemesi gereken zaman

    #endregion

    #region UserSettings
      options.User.RequireUniqueEmail = true;//Benzersiz email adresi ile kay�t olunabilir, ayn� email ile birden fazla kay�t yap�lamaz.

    #endregion

    #region SignInSetting
    options.SignIn.RequireConfirmedEmail = false; //True ise email onay� aktiftir.
    options.SignIn.RequireConfirmedPhoneNumber = false; //true ise telefon numaras� onay� aktiftir.
    #endregion

});

builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath = "/account/login";//E�er a��labilmesi i�in login olman�n zorunlu olfu�u sayfadan istekte bulunulursa kullan�c�n�n y�nlendirilece�i sayfa buras� olacak. (account controller�ndaki login action metodu    
    options.LogoutPath= "/account/logout"; //Kullan�c� ��k�� yapt���nda y�nlendirilecek sayfa
    options.AccessDeniedPath = "/account/accessdenied"; //Yetkisiz giri� sras�nda y�nlendirilecek sayfa
    options.SlidingExpiration = true; //Varsay�lan cookie ya�am s�resinin(20dk) ya da ayarlanan a�am s�resinin her yeni istek s�ras�nda s�f�rlanarak yeniden ba�lamas�n sa�lamak
    options.ExpireTimeSpan= TimeSpan.FromMinutes(5); //ya�am s�resini ayarlar.
    options.Cookie = new CookieBuilder
    {
        HttpOnly= true,
        Name=".ShoppingApp.Security.Cookie" ,
        SameSite = SameSiteMode.Strict //G�vnelik amac�yla yap�lr.
    };
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();


builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender(
    "smtp.office365.com", 587, true , "wissen_core@hotmail.com", "Wissen123." //hotmail i�in gereken bilgiler
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
