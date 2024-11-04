using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManagement.MVC.Permission
{
internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    public PermissionAuthorizationHandler()
    {

    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        if (context.User == null)
        {
            return;
        }
            var permissionss = context.User.Claims.Where(x => x.Type == "Permission" &&
                                                            x.Value == requirement.Permission &&
                                                            x.Issuer == "LOCAL AUTHORITY");
        if (permissionss.Any())
        {
            context.Succeed(requirement);
            return;
        }
    }
}
}