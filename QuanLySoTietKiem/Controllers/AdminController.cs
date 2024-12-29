using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuanLySoTietKiem.Data;
using QuanLySoTietKiem.Models;

namespace QuanLySoTietKiem.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdminController> _logger;
        [ActivatorUtilitiesConstructor]
        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Report()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            return View();
        }
        // User Management  
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return View(users);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReportByDay()
        {
            // Get today's date at midnight
            var today = DateTime.Today;

            // Get all transactions for today
            var report = await GenerateDailyReport(today);
            return View(report);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReportByDay(DateTime date)
        {
            var report = await GenerateDailyReport(date);
            return View(report);
        }
        private async Task<BaoCaoNgay> GenerateDailyReport(DateTime date)
        {
            // Get transactions for the specified date
            var transactions = await _context.GiaoDichs
                .Include(g => g.SoTietKiem)
                .ThenInclude(s => s.LoaiSoTietKiem)
                .Where(g => g.NgayGiaoDich.Date == date.Date)
                .ToListAsync();

            // Calculate totals
            decimal tongTienGui = transactions
                .Where(t => t.MaLoaiGiaoDich == 2) // Mã 2 là giao dịch gửi tiền
                .Sum(t => (decimal)t.SoTien);

            decimal tongTienRut = transactions
                .Where(t => t.MaLoaiGiaoDich == 1) // Mã 1 là giao dịch rút tiền  
                .Sum(t => (decimal)t.SoTien);

            var report = new BaoCaoNgay
            {
                Ngay = date,
                TongTienGui = tongTienGui,
                TongTienRut = tongTienRut,
                NgayTaoBaoCao = DateTime.Now
            };

            return report;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ExportToPdf(DateTime date)
        {
            var report = await GenerateDailyReport(date);

            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                // Add title
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var title = new Paragraph($"Báo Cáo Ngày {date:dd/MM/yyyy}", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                // Add content
                var contentFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                document.Add(new Paragraph($"Tong tien gui: {report.TongTienGui:N0} VNĐ", contentFont));
                document.Add(new Paragraph($"Tong tien rut: {report.TongTienRut:N0} VNĐ", contentFont));
                document.Add(new Paragraph($"Chech lech: {(report.TongTienGui - report.TongTienRut):N0} VNĐ", contentFont));
                document.Add(new Paragraph($"Thoi diem tao bao cao: {report.NgayTaoBaoCao:dd/MM/yyyy HH:mm:ss}", contentFont));

                document.Close();
                writer.Close();

                return File(ms.ToArray(), "application/pdf", $"BaoCaoNgay_{date:ddMMyyyy}.pdf");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ExportToExcel(DateTime date)
        {
            var report = await GenerateDailyReport(date);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Báo Cáo Ngày");

                // Add title
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = $"Báo Cáo Ngày {date:dd/MM/yyyy}";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Add content
                worksheet.Cells["A3"].Value = "Tổng tiền gửi:";
                worksheet.Cells["B3"].Value = report.TongTienGui;
                worksheet.Cells["B3"].Style.Numberformat.Format = "#,##0";

                worksheet.Cells["A4"].Value = "Tổng tiền rút:";
                worksheet.Cells["B4"].Value = report.TongTienRut;
                worksheet.Cells["B4"].Style.Numberformat.Format = "#,##0";

                worksheet.Cells["A5"].Value = "Chênh lệch:";
                worksheet.Cells["B5"].Value = report.TongTienGui - report.TongTienRut;
                worksheet.Cells["B5"].Style.Numberformat.Format = "#,##0";

                worksheet.Cells["A6"].Value = "Thời điểm tạo báo cáo:";
                worksheet.Cells["B6"].Value = report.NgayTaoBaoCao;
                worksheet.Cells["B6"].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                worksheet.Columns.AutoFit();

                return File(package.GetAsByteArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"BaoCaoNgay_{date:ddMMyyyy}.xlsx");
            }
        }
    }
}
