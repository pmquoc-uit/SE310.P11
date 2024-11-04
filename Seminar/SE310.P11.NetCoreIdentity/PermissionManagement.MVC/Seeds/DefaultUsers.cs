using Microsoft.AspNetCore.Identity;
using PermissionManagement.MVC.Constants;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PermissionManagement.MVC.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "basicuser@gmail.com",
                Email = "basicuser@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
        }

        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }

            var myUser = new IdentityUser
            {
                UserName = "pmq@gmail.com",
                Email = "pmq@gmail.com",
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
                    foreach (var role in Enum.GetValues(typeof(Roles)))
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

        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Products");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}