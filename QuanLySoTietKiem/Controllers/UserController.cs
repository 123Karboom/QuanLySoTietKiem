using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLySoTietKiem.Models;
using QuanLySoTietKiem.Models.AccountModels.ChangePasswordModel;
using QuanLySoTietKiem.Services.Interfaces;


namespace QuanLySoTietKiem.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISoTietKiemService _soTietKiemService;
        public UserController(ILogger<UserController> logger, UserManager<ApplicationUser> userManager, ISoTietKiemService soTietKiemService)
        {
            _logger = logger;
            _userManager = userManager;
            _soTietKiemService = soTietKiemService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            bool isRole = await _userManager.IsInRoleAsync(currentUser, "User");
            Console.WriteLine(isRole);
            if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return RedirectToAction("Dashboard", "User");
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Dashboard()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            // Hiển thị tổng số sổ tiết kiệm của người dùng
            var count = await _soTietKiemService.CountSoTietKiem(currentUser.Id);
            ViewBag.UserName = currentUser.FullName;
            ViewBag.ThongBao = "Hello " + currentUser.FullName + " đã quay trở lại hệ thống 😊";
            ViewBag.CountSoTietKiem = count;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Profile()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(currentUser);
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(ApplicationUser model)
        {
            _logger.LogInformation("EditProfile action called");
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                user.FullName = model.FullName;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Profile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User) ?? throw new Exception("User not found");
                var result = await _userManager.ChangePasswordAsync(currentUser, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard");
                }
                //Add errors to ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

    }
}
