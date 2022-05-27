using DataBaseStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddScoped<IDepartmentManager, DepartmentManager>();
services.AddScoped<IDisciplineManager, DisciplineManager>();
services.AddScoped<IGroupManager, GroupManager>();
services.AddScoped<IStudentManager, StudentManager>();
services.AddScoped<ITeacherManager, TeacherManager>();
services.AddScoped<ISpecialityManager, SpecialityManager>();

// Add DataBase Context.
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
services.AddDbContext<UniversityContext>(param => param.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Teachers",
        pattern: "Teachers/main",
        defaults: new { controller = "Teachers", action = "main" });

    endpoints.MapControllerRoute(name: "Students",
        pattern: "Students/main",
        defaults: new { controller = "Students", action = "main" });

    endpoints.MapControllerRoute(name: "Disciplines",
        pattern: "Disciplines/main",
        defaults: new { controller = "Disciplines", action = "main" });

    endpoints.MapControllerRoute(name: "Groups",
        pattern: "Groups/main",
        defaults: new { controller = "Groups", action = "main" }); 

    endpoints.MapControllerRoute(name: "Specialitys",
        pattern: "Specialitys/main",
        defaults: new { controller = "Specialitys", action = "main" });

    endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Students}/{action=main}/{id?}");
});
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Departments}/{action=Main}/{id?}");

app.Run();
