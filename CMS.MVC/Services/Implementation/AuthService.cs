using CMS.API.Configuration;
using CMS.DATA.Context;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Identity;

namespace CMS.MVC.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly CMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IEmailService _emailService;

        //private readonly IMapper _mapper;

        public AuthService(CMSDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signinManager, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _emailService = emailService;
        }


        public async Task<ResponseDto<ResetPassword>> ResetPasswords(ResetPassword resetPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                if (user == null)
                {
                    var response = new ResponseDto<ResetPassword>
                    {
                        StatusCode = 404,
                        DisplayMessage = "User not found",
                        Result = null,
                        ErrorMessages = new List<string> { "The user with the specified email address was not found" }
                    };
                    return response;
                }

                var resetResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

                if (resetResult.Succeeded)
                {
                    var response = new ResponseDto<ResetPassword>
                    {
                        StatusCode = 200,
                        DisplayMessage = "Password reset successful",
                        Result = resetPassword,
                        ErrorMessages = null
                    };
                    return response;
                }
                else
                {
                    var response = new ResponseDto<ResetPassword>
                    {
                        StatusCode = 500,
                        DisplayMessage = "Password reset failed",
                        Result = null,
                        ErrorMessages = new List<string> { "An error occurred while resetting the password" }
                    };
                    return response;
                }

            }
            catch (Exception ex)
            {
                var response = new ResponseDto<ResetPassword>
                {
                    StatusCode = 500,
                    DisplayMessage = "Internal Server Error",
                    Result = null,
                    ErrorMessages = new List<string> { $"{ex.Message}", "An error occurred while resetting the password" }
                };
                return response;
            }
        }

        public async Task<ResponseDto<string>> Logout()
        {

            await _signinManager.SignOutAsync();
            var response = new ResponseDto<string>
            {
                StatusCode = StatusCodes.Status200OK,
                DisplayMessage = "Logout successful",
                Result = null,
                ErrorMessages = null
            };
            return response;
        }
        public async Task<ResponseDto<string>> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var tokens = await _userManager.GeneratePasswordResetTokenAsync(user);
                if (tokens != null)
                {
                    // Send email with the generated token
                    var message = new Message(new string[] { email }, "Reset Password Token", $"Your reset password token is: {tokens}");
                    _emailService.SendEmail(message);
                    return new ResponseDto<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        DisplayMessage = $"Reset password token generated and sent to email: {email}",
                        Result = tokens
                    };
                }
                return new ResponseDto<string>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DisplayMessage = "Token not generated",
                };
            }

            return new ResponseDto<string>
            {
                StatusCode = StatusCodes.Status404NotFound,
                DisplayMessage = $"Email not found: {email}",
                ErrorMessages = new List<string> { $"Email not found: {email}" }
            };
        }
    }
}
