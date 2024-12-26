using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLySoTietKiem.Data;
using QuanLySoTietKiem.Models;
using QuanLySoTietKiem.Models.SavingsAccount;
using QuanLySoTietKiem.Services.Interfaces;

namespace QuanLySoTietKiem.Controllers
{
    public class SoTietKiemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<SoTietKiemController> _logger;
        private readonly ISoTietKiemService _soTietKiemService;


        [ActivatorUtilitiesConstructor]
        public SoTietKiemController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<SoTietKiemController> logger, ISoTietKiemService soTietKiemService)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _soTietKiemService = soTietKiemService;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var soTietKiems = await _context.SoTietKiems
                .Where(s => s.UserId == currentUser.Id)
                .ToListAsync();
            _logger.LogInformation("SoTietKiems: {soTietKiems}", soTietKiems.Count);
            var model = soTietKiems.Select(stk => new SoTietKiemModel
            {
                MaSoTietKiem = stk.MaSoTietKiem,
                UserId = stk.UserId,
                SoTienGui = stk.SoTienGui,
                NgayMoSo = stk.NgayMoSo,
                MaHinhThucDenHan = stk.MaHinhThucDenHan,
                LaiSuatApDung = stk.LaiSuatApDung,
                NgayDongSo = stk.NgayDongSo ?? DateTime.Now.AddDays(stk.MaLoaiSo * 30),
                TrangThai = stk.TrangThai,
                Code = stk.Code,
                MaLoaiSo = stk.MaLoaiSo,
                SoDuSoTietKiem = stk.SoDuSoTietKiem,
            
            });

            _logger.LogInformation("Model: {model}", model);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> OpenSavingsAccount()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            // Lấy số dư tài khoản của người dùng
            ViewBag.SoDuHienTai = currentUser?.SoDuTaiKhoan ?? 0;
            // log số dư tài khoản của người dùng
            _logger.LogInformation("SoDuHienTai: {SoDuHienTai}", currentUser?.SoDuTaiKhoan);
            // Fetch HinhThucDenHan options synchronously
            var hinhThucDenHanOptions = await _context.HinhThucDenHans.ToListAsync();
            _logger.LogInformation("HinhThucDenHanOptions: {HinhThucDenHanOptions}", hinhThucDenHanOptions.Select(ht => ht.TenHinhThucDenHan));
            ViewBag.HinhThucDenHanOptions = new SelectList(hinhThucDenHanOptions, "MaHinhThucDenHan", "TenHinhThucDenHan");
            ViewBag.CodeSTK = GenerateCode(currentUser?.Id ?? "");
            //Fetch LoaiSoTietKiem 
            var LoaiSoTietKiemOptions = await _context.LoaiSoTietKiems.ToListAsync();
            _logger.LogInformation("LoaiSoTietKiemOptions: {LoaiSoTietKiemOptions}", LoaiSoTietKiemOptions.Select(ls => ls.TenLoaiSo));
            ViewBag.LoaiSoTietKiemOptions = new SelectList(LoaiSoTietKiemOptions, "MaLoaiSo", "TenLoaiSo");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> OpenSavingsAccount(SoTietKiemModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Set required properties before ModelState validation
            model.UserId = currentUser.Id;
            model.NgayMoSo = DateTime.Now;
            model.TrangThai = true;
            model.Code = GenerateCode(currentUser.Id);
            model.LaiSuatApDung = TinhLaiSuat(model.MaLoaiSo);
            model.LaiSuatKyHan = model.LaiSuatApDung;
            model.SoDuSoTietKiem = model.SoTienGui;

            // Clear ModelState and revalidate with the updated values
            ModelState.Clear();
            if (TryValidateModel(model))
            {
                if (currentUser.SoDuTaiKhoan < (double)model.SoTienGui)
                {
                    ModelState.AddModelError("SoTienGui", "Số dư tài khoản không đủ");
                    ViewBag.SoDuHienTai = currentUser.SoDuTaiKhoan;
                    await PopulateViewBagDropdowns();
                    return View(model);
                }

                var soTietKiem = new SoTietKiem
                {
                    UserId = currentUser.Id,
                    SoTienGui = model.SoTienGui,
                    NgayMoSo = model.NgayMoSo,
                    MaHinhThucDenHan = model.MaHinhThucDenHan,
                    MaLoaiSo = model.MaLoaiSo,
                    LaiSuatApDung = model.LaiSuatApDung,
                    TrangThai = model.TrangThai,
                    Code = model.Code,
                    SoDuSoTietKiem = model.SoDuSoTietKiem,
                    LaiSuatKyHan = model.LaiSuatKyHan,
                    NgayDongSo = null
                };

                _logger.LogInformation("SoTietKiem: {@SoTietKiem}", soTietKiem);
                currentUser.SoDuTaiKhoan -= (double)model.SoTienGui;
                await _userManager.UpdateAsync(currentUser);

                await _context.SoTietKiems.AddAsync(soTietKiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _logger.LogError("ModelState is not valid: {@ModelStateErrors}",
                ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

            await PopulateViewBagDropdowns();
            ViewBag.SoDuHienTai = currentUser.SoDuTaiKhoan;
            ViewBag.CodeSTK = model.Code;
            return View(model);
        }

        private decimal TinhLaiSuat(int kyHan)
        {
            // Định nghĩa lãi suất theo kỳ hạn
            return kyHan switch
            {

                3 => 0.05m, // 3% cho 3 tháng
                6 => 0.055m, // 4% cho 6 tháng
                _ => 0.005m, // 1% cho các trường hợp khác
            };
        }
        private string GenerateCode(string userId)
        {
            return "STK" + "-" + userId + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private async Task PopulateViewBagDropdowns()
        {
            var hinhThucDenHanOptions = await _context.HinhThucDenHans.ToListAsync();
            ViewBag.HinhThucDenHanOptions = new SelectList(hinhThucDenHanOptions, "MaHinhThucDenHan", "TenHinhThucDenHan");

            var LoaiSoTietKiemOptions = await _context.LoaiSoTietKiems.ToListAsync();
            ViewBag.LoaiSoTietKiemOptions = new SelectList(LoaiSoTietKiemOptions, "MaLoaiSo", "TenLoaiSo");
        }
        //Lấy thông tin chi tiết sổ tiết kiệm
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Details(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var soTietKiem = await _context.SoTietKiems.FirstOrDefaultAsync(s => s.MaSoTietKiem == id && s.UserId == currentUser.Id);
            if (soTietKiem == null)
            {
                return NotFound();
            }
            var model = new SoTietKiemDetailModel
            {
                MaSoTietKiem = soTietKiem.MaSoTietKiem,
                Code = soTietKiem.Code ?? "",
                SoTienGui = soTietKiem.SoTienGui,
                SoDuSoTietKiem = soTietKiem.SoDuSoTietKiem,
                LaiSuatApDung = soTietKiem.LaiSuatApDung,
                LaiSuatKyHan = soTietKiem.LaiSuatKyHan,
                NgayMoSo = soTietKiem.NgayMoSo,
                NgayDongSo = soTietKiem.NgayDongSo,
                TrangThai = soTietKiem.TrangThai,
                TenLoaiSo = soTietKiem.LoaiSoTietKiem?.TenLoaiSo ?? "",
                KyHan = soTietKiem.LoaiSoTietKiem?.KyHan ?? 0,
                TenHinhThucDenHan = soTietKiem.HinhThucDenHan?.TenHinhThucDenHan ?? "",
                TenKhachHang = soTietKiem.User?.FullName ?? "unknown"
            };
            return View(model);
        }
        //Load trang nạp tiền vào sổ tiết kiệm
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddMoney(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var soTietKiem = await _context.SoTietKiems.FirstOrDefaultAsync(m => m.MaSoTietKiem == id);
            ViewBag.CodeSTK = await _soTietKiemService.GetCodeSTK(currentUser.Id, id);
            ViewBag.SoDuHienTai = currentUser.SoDuTaiKhoan;
            if (soTietKiem == null)
            {
                return NotFound();
            }

            var model = new AddMoneyViewModel
            {
                MaSoTietKiem = id,
                SoDuHienTai = soTietKiem.SoDuSoTietKiem
            };

            return View(model);
        }
        //Xử lý nạp tiền vào sổ tiết kiệm
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMoney(AddMoneyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var soTietKiem = await _context.SoTietKiems.FirstOrDefaultAsync(m => m.MaSoTietKiem == model.MaSoTietKiem);
            if (soTietKiem == null)
            {
                return NotFound();
            }

            //Kiểm tra số dư tài khoản của người dùng
            if (currentUser.SoDuTaiKhoan < (double)model.SoTienGui)
            {
                ModelState.AddModelError("SoTienGui", "Số dư tài khoản không đủ");
                return View(model);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                //Cập nhật số dư sổ tiết kiệm
                soTietKiem.SoDuSoTietKiem += model.SoTienGui;

                //Trừ tiền từ tài khoản người dùng
                currentUser.SoDuTaiKhoan -= (double)model.SoTienGui;
                await _userManager.UpdateAsync(currentUser);

                // //Tạo phiếu gửi tiền
                // var phieuGuiTien = new QuanLySoTietKiem.Models.PhieuGuiTienModel
                // {
                //     MaSoTietKiem = model.MaSoTietKiem,
                //     SoTienGui = model.SoTienGui,
                //     NgayGui = DateTime.Now,
                // };

                // await _context.PhieuGuiTiens.AddAsync(phieuGuiTien);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                // TempData["SuccessMessage"] = $"Nạp tiền thành công. Mã giao dịch: {phieuGuiTien.MaGiaoDich}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Lỗi khi nạp tiền vào sổ tiết kiệm");
                ModelState.AddModelError("", "Có lỗi xảy ra khi nạp tiền. Vui lòng thử lại sau.");
                return View(model);
            }
        }

        private string GenerateTransactionCode(string userId)
        {
            return $"PGT-{userId.Substring(0, 4)}-{DateTime.Now:yyyyMMddHHmmss}";
        }

        //Xử lý rút tiền 
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> WithdrawMoney()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
      
    }
}
