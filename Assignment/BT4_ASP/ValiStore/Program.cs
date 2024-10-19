using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using ValiStore.Models;
using ValiStore.Repository;

namespace ValiStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            Action<DbContextOptionsBuilder> dbContextOptions = options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            builder.Services.AddDbContext<QlbanVaLiContext>(dbContextOptions);
            builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();
            builder.Services.AddSession();

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
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
