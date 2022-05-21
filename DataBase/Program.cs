using DataBaseStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Teachers}/{action=Main}/{id?}");

app.Run();
