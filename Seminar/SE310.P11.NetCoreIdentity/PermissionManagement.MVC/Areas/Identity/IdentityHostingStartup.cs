using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PermissionManagement.MVC.Areas.Identity.IdentityHostingStartup))]
namespace PermissionManagement.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
