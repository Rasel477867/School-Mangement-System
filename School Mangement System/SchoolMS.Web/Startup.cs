using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolMS.Repository.Data;
using SchoolMS.Core.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolMS.Repository.Contacts;
using SchoolMS.Repository;
using SchoolMS.Service.Contacts;
using SchoolMS.Service;
using SchoolMS.Web.ViewModels;

namespace SchoolMS.Web
{
    public static class Startup
    {
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            //Dbcontext Dependency Injection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //Identity Dependency Injection
            builder.Services.AddIdentity<AppUser, IdentityRole>(
                 options =>
                  {
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;

                  }
                  )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //automaper service Register
            builder.Services.AddAutoMapper(typeof(DomainMaper));
               


            // All Dependency Injection here

            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();
            builder.Services.AddScoped<IClassLevelRepository, ClassLevelRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

            builder.Services.AddScoped<ITeacherService,TeacherService>();
            builder.Services.AddScoped<IDesignationService, DesignationService>();
            builder.Services.AddScoped<IClassLevelService, ClassLevelService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();

       


        }
        private static void Configure(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }


    }
}
