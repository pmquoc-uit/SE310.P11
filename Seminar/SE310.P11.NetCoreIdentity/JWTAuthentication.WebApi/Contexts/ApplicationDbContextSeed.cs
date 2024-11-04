using JWTAuthentication.WebApi.Constants;
using JWTAuthentication.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.WebApi.Contexts
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            var rolesExist = await roleManager.Roles.AnyAsync();
            if (!rolesExist)
            {
                await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Administrator.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Moderator.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.User.ToString()));
            }
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = Authorization.default_username,
                Email = Authorization.default_email,
                FirstName = Authorization.default_username,
                LastName = Authorization.default_username,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, Authorization.default_password);
                await userManager.AddToRoleAsync(defaultUser, Authorization.default_role.ToString());
                await userManager.AddToRoleAsync(defaultUser, Authorization.Roles.Administrator.ToString());
            }
        }
    }
}
