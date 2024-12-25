using Microsoft.AspNetCore.Identity;
using QuanLySoTietKiem.Data;
using QuanLySoTietKiem.Models;
using QuanLySoTietKiem.Models.AccountModels.ForgotPassword;
using QuanLySoTietKiem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace QuanLySoTietKiem.Services
{
    public class AccountService : IAccountService
    {



        public AccountService()
        {
        }

        /*public async Task<bool> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return false;
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = _urlHelper.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code = token },
                protocol: _httpContextAccessor.HttpContext.Request.Scheme);

            var message = $@"
                <h3>Reset Your Password</h3>
                <p>Please reset your password by <a href='{callbackUrl}'>clicking here</a></p>
                <p>If you did not request a password reset, please ignore this email.</p>";

            await _emailService.SendEmailAsync(
                model.Email,
                "Reset Password",
                message);
                
                
            return true;
        }*/


    }
}
