using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace API.Controllers;

public class AccountController
    (SignInManager<AppUser> signInManager, IEmailPublisherService mailService, IPasswordHasher<AppUser> passwordHasher) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            UserName = registerDto.Email
        };

        var result = await signInManager.UserManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return NoContent();
    }

    [HttpGet("user-info")]
    public async Task<ActionResult> GetUserInfo()
    {
        if (User.Identity?.IsAuthenticated == false) return NoContent();

        var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);

        return Ok(new
        {
            user.FirstName,
            user.LastName,
            user.Email,
            Address = user.Address?.ToDto(),
            Roles = User.FindFirstValue(ClaimTypes.Role)
        });
    }

    [Authorize]
    [HttpPost("user-info")]
    public async Task<ActionResult> UpdateUserInfo(UpdateUserRequest request)
    {
        var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        var result = await signInManager.UserManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Ok("User Info updated");
        }
        return BadRequest("Failed to update User Info!");
    }

    [HttpGet("auth-status")]
    public ActionResult GetAuthState()
    {
        return Ok(new { IsAuthenticated = User.Identity?.IsAuthenticated ?? false });
    }

    [Authorize]
    [HttpPost("address")]
    public async Task<ActionResult<Address>> CreateOrUpdateAddress(AddressDto addressDto)
    {
        var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);

        if (user.Address == null)
        {
            user.Address = addressDto.ToEntity();
        }
        else
        {
            user.Address.UpdateFromDto(addressDto);
        }

        var result = await signInManager.UserManager.UpdateAsync(user);

        if (!result.Succeeded) return BadRequest("Problem updating user address");

        return Ok(user.Address.ToDto());
    }

    [Authorize]
    [HttpPost("reset-password")]
    public async Task<ActionResult> ResetPassword(string currentPassword, string newPassword)
    {
        var user = await signInManager.UserManager.GetUserByEmail(User);

        var result = await signInManager.UserManager.ChangePasswordAsync(user, currentPassword, newPassword);

        if (result.Succeeded)
        {
            return Ok("Password updated");
        }

        return BadRequest("Failed to update password");
    }
    [Authorize]
    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePWRequest request)
    {
        var user = await signInManager.UserManager.GetUserByEmail(User);

        var result = await signInManager.UserManager.ChangePasswordAsync
            (user, request.CurrentPassword, request.NewPassword);

        if (result.Succeeded)
        {
            return Ok("Password updated");
        }

        return BadRequest("Failed to update password");
    }
    [Authorize]
    [HttpGet("is-google")]
    public async Task<ActionResult> IsGooogle()
    {
        var user = await signInManager.UserManager.GetUserByEmail(User);
        var isGG = passwordHasher
            .VerifyHashedPassword(user, user.PasswordHash!, "GoogleAuth1!")
                == PasswordVerificationResult.Success;
        return Ok(new { IsGoogle = isGG });
    }
    [HttpGet("send-mail/{email}")]
    public async Task<IActionResult> SendMail(String email)
    {
        if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
        {
            return BadRequest("Invalid email format.");
        }
        var user = await signInManager.UserManager.FindByEmailAsync(email);
        if (user == null)
        {
            return NotFound("User not found.");
        }
        var isGG = passwordHasher
            .VerifyHashedPassword(user, user.PasswordHash!, "GoogleAuth1!")
                == PasswordVerificationResult.Success;
        if (isGG)
        {
            return BadRequest("Google Sign-In user cannot reset password!");
        }
        var token = await signInManager.UserManager.GeneratePasswordResetTokenAsync(user);
        //var randomPassword = GenerateRandomPassword();
        //var resetResult = await signInManager.UserManager.ResetPasswordAsync(user, token, randomPassword);
        var result = await signInManager.UserManager.ResetPasswordAsync(user, token, "Random123!");
        if (!result.Succeeded)
        {
            return BadRequest("Failed to reset password.");
        }
        // Tạo yêu cầu email và gửi thông báo
        try
        {
            ForgotPWRequest request = new ForgotPWRequest
            {
                ToEmail = email,
                Password = "Random123!",
            };
            //await mailService.SendEmailAsync(request);
            //return Ok("Password sent to your email!");

            // Publish vào RabbitMQ
            mailService.PublishToRabbitMQ(request);
            return Ok("Password reset email has been queued!");
        }
        catch (Exception ex)
        {
            // Ghi log hoặc xử lý lỗi gửi email
            return BadRequest($"Internal server error: {ex.Message}");
        }
    }
    private string GenerateRandomPassword(int length = 12)
    {
        var random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
        return new string(Enumerable.Range(0, length)
            .Select(_ => chars[random.Next(chars.Length)])
            .ToArray());
    }
}
