using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuredController(IHttpContextAccessor context) : ControllerBase
    {
        [HttpGet]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> GetSecuredData()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            Console.WriteLine(context.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "roles")?.Value);

            return Ok("This Secured Data is available only for Authenticated Users.");
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> PostSecuredData()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return Ok("This Secured Data is available only for Administrators.");
        }
    }
}