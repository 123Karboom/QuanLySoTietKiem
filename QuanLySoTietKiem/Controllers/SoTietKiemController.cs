using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLySoTietKiem.Data;
using QuanLySoTietKiem.Models;

namespace QuanLySoTietKiem.Controllers
{
    public class SoTietKiemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<SoTietKiemController> _logger;

        public SoTietKiemController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<SoTietKiemController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var soTietKiems = await _context.SoTietKiems
                .Where(s => s.UserId == currentUser.Id)
                .ToListAsync();
            _logger.LogInformation("SoTietKiems: {soTietKiems}", soTietKiems);
            var model = soTietKiems.Select(stk => new SoTietKiemModel
            {
                Id = stk.MaSoTietKiem,
                UserId = stk.UserId,
                SoTienGui = stk.SoTienGui,

                NgayMoSo = stk.NgayMoSo,

            });
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> OpenSavingsAccount()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.SoDuHienTai = currentUser?.SoDuTaiKhoan;
            return View();
        }

        // [HttpPost]
        // [Authorize(Roles = "User")]
        // public async Task<IActionResult> OpenSavingsAccount(SoTietKiemModel model)
        // {
        //     var currentUser = await _userManager.GetUserAsync(User);
        //     _logger.LogInformation("Current user: {currentUser}", currentUser);
        //     if (ModelState.IsValid)
        //     {
        //         if (currentUser.SoDuTaiKhoan < (double)model.SoTienGui)
        //         {
        //             ModelState.AddModelError("SoTienGui", "Số dư tài khoản không đủ");
        //             ViewBag.SoDuHienTai = currentUser.SoDuTaiKhoan;
        //             return View(model);
        //         }

        //         var soTietKiem = new SoTietKiem
        //         {
        //             UserId = currentUser.Id,
        //             SoTienGui = model.SoTienGui,
        //             NgayMoSo = DateTime.Now,
        //             LaiSuatApDung = TinhLaiSuat(model.KyHan)
        //         };

        //         // Trừ tiền từ tài khoản
        //         currentUser.SoDuTaiKhoan -= (double)model.SoTienGui;
        //         await _userManager.UpdateAsync(currentUser);

        //         // Lưu sổ tiết kiệm
        //         _context.SoTietKiems.Add(soTietKiem);
        //         await _context.SaveChangesAsync();

        //         return RedirectToAction(nameof(Index));
        //     }

        //     ViewBag.SoDuHienTai = currentUser.SoDuTaiKhoan;
        //     return View(model);
        // }

        // private double TinhLaiSuat(int kyHan)
        // {
        //     // Định nghĩa lãi suất theo kỳ hạn
        //     return kyHan switch
        //     {
        //         1 => 0.02, // 2% cho 1 tháng
        //         3 => 0.03, // 3% cho 3 tháng
        //         6 => 0.04, // 4% cho 6 tháng
        //         12 => 0.05, // 5% cho 12 tháng
        //         _ => 0.01, // 1% cho các trường hợp khác
        //     };
        // }
    }
}
