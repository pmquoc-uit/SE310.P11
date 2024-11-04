using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PermissionManagement.MVC.Constants;
using System.Threading.Tasks;

namespace PermissionManagement.MVC.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var rolesExist = await roleManager.Roles.AnyAsync();
            if (!rolesExist)
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
            }
        }
    }
}