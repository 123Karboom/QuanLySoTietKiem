using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLySoTietKiem.Models;

namespace QuanLySoTietKiem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BaoCaoNgay> BaoCaoNgays { get; set; }
        public DbSet<BaoCaoThang> BaoCaoThangs { get; set; }
        public DbSet<LoaiSoTietKiem> LoaiSoTietKiems { get; set; }
        public DbSet<SoTietKiem> SoTietKiems { get; set; }
        public DbSet<PhieuRutTien> PhieuRutTiens { get; set; }
        public DbSet<PhieuGuiTien> PhieuGuiTiens { get; set; }
    }
}
