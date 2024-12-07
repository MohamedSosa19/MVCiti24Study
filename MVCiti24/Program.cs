using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCiti24.Interface;
using MVCiti24.Models;
using MVCiti24.Repositories;

namespace MVCiti24
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ITIContectDB>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ITI"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ITIContectDB>();

            builder.Services.AddScoped<InstructorRepository>();  // Register InstructorRepository directly
            builder.Services.AddScoped<CourseRepository>();     // Register CourseRepository
            builder.Services.AddScoped<DepartmentRepository>(); // Register DepartmentRepository
            builder.Services.AddScoped<ITIContectDB>();         // Register the DB context if not registered



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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
