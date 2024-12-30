using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLySoTietKiem.Models;
using QuanLySoTietKiem.Models.AccountModels.ChangePasswordModel;
using QuanLySoTietKiem.Models.AccountModels.ForgotPassword;
using QuanLySoTietKiem.Services.Interfaces;
using LoginModel = QuanLySoTietKiem.Models.AccountModels.LoginModel.LoginModel;
using RegisterModel = QuanLySoTietKiem.Models.AccountModels.RegisterrModel.RegisterModel;

namespace QuanLySoTietKiem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }
        //Đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        //Xử lý trang đăng nhập
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
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
                    return RedirectToAction("Index", "User");
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

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "User");
            }
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

                //assign role 
                if (result.Succeeded)
                {
                    Console.WriteLine("User created successfully");
                    await _userManager.AddToRoleAsync(user, "User");
                }


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
        //Logout 
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        //Forgot password 
        [HttpGet]
        public IActionResult ForgotPassword()
        {

            return View();
        }
        // Forgot password

    }
}
