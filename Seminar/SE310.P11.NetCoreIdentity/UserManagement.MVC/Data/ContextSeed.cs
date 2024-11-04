using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            var roleExists = await roleManager.Roles.AnyAsync();
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Moderator.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
            }
        }
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Mukesh",
                LastName = "Murugan",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
                }
            }

            var myUser = new ApplicationUser
            {
                UserName = "PMQ",
                Email = "pmq@gmail.com",
                FirstName = "Minh Quoc",
                LastName = "Pham",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            // Kiểm tra xem người dùng đã tồn tại chưa
            var exUser = await userManager.FindByEmailAsync(myUser.Email);
            if (exUser == null)
            {
                // Tạo người dùng mới
                var result = await userManager.CreateAsync(myUser, "Qq111111!");
                if (result.Succeeded)
                {
                    // Kiểm tra và tạo các vai trò nếu chưa tồn tại
                    foreach (var role in Enum.GetValues(typeof(Enums.Roles)))
                    {
                        var roleName = role.ToString();
                        if (!await roleManager.RoleExistsAsync(roleName))
                        {
                            await roleManager.CreateAsync(new IdentityRole(roleName));
                        }
                        // Thêm người dùng vào vai trò
                        await userManager.AddToRoleAsync(myUser, roleName);
                    }
                }
                else
                {
                    // Xử lý lỗi nếu tạo người dùng không thành công
                    throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
