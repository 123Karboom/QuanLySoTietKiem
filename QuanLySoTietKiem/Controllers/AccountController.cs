using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using QuanLySoTietKiem.Models;
using LoginModel = QuanLySoTietKiem.Models.AccountModels.LoginModel.LoginModel;
using RegisterModel = QuanLySoTietKiem.Models.AccountModels.RegisterrModel.RegisterModel;

namespace QuanLySoTietKiem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager; 
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet] 
        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "User does not exist.");
                    return View(model);
                }

                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Email is not confirmed. Please check your inbox.");
                    return View(model);
                }

                if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTimeOffset.UtcNow)
                {
                    ModelState.AddModelError("", "Your account is locked. Please try again later.");
                    return View(model);
                }

                // Check password manually (for debugging purposes)
                var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!isPasswordCorrect)
                {
                    ModelState.AddModelError("", "Incorrect password.");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your account is locked due to multiple failed attempts.");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName,
                    Address = model.Address,
                    CCCD = model.CCCD,
                    SoDuTaiKhoan = model.SoDuTaiKhoan,
                    PhoneNumber = model.PhoneNumber,
                    PhoneNumberConfirmed = true, 
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}
