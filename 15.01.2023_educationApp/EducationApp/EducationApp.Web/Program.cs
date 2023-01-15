using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Data.Abstract;
using EducationApp.Data.Concrete;
using EducationApp.Data.Concrete.EfCore.Contexts;
using EducationApp.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();

builder.Services.AddDbContext<EducationAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<EducationAppContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "students",
    pattern: "students",
    defaults: new { controller = "Student", action = "Index" }

    );
app.MapControllerRoute(
    name: "teachers",
    pattern: "teachers",
    defaults: new { controller = "Teacher", action = "Index" }

    );

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"); ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
