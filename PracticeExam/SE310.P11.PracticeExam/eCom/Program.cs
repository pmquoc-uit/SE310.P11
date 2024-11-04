using eCom.Models;
using eCom.Repository;
using Microsoft.EntityFrameworkCore;

namespace eCom
{
    public class Program
    {
        public static void DataMigration(WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var services = scope.ServiceProvider;
            var appDbContext = services.GetRequiredService<EComContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                appDbContext.Database.Migrate();
                logger.LogInformation("Data migration completed successfully!\n");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during migration!\n");
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EComContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(EComContext).Assembly.FullName)));
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

            app.UseSession();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            DataMigration(app);

            app.Run();
        }
    }
}
