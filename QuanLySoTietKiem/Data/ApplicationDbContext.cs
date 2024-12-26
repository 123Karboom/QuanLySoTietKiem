using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLySoTietKiem.Models;

namespace QuanLySoTietKiem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LoaiSoTietKiem> LoaiSoTietKiems { get; set; }
        public DbSet<SoTietKiem> SoTietKiems { get; set; }
        public DbSet<BaoCaoNgay> BaoCaoNgays { get; set; }
        public DbSet<BaoCaoThang> BaoCaoThangs { get; set; }
        public DbSet<PhieuRutTien> PhieuRutTiens { get; set; }
        public DbSet<PhieuGuiTien> PhieuGuiTiens { get; set; }
        public DbSet<HinhThucDenHan> HinhThucDenHans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define primary key for IdentityUserLogin<string>
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<BaoCaoThang>().Property(b => b.ChenhLech).HasPrecision(18, 2);
            modelBuilder.Entity<BaoCaoNgay>().Property(b => b.TongTienGui).HasPrecision(18, 2);
            modelBuilder.Entity<BaoCaoNgay>().Property(b => b.TongTienRut).HasPrecision(18, 2);
            modelBuilder.Entity<LoaiSoTietKiem>().Property(l => l.SoTienGuiToiThieu).HasPrecision(18, 2);
            modelBuilder.Entity<SoTietKiem>().Property(s => s.SoDuSoTietKiem).HasPrecision(18, 2);
            modelBuilder.Entity<SoTietKiem>().Property(s => s.SoTienGui).HasPrecision(18, 2);
            modelBuilder.Entity<SoTietKiem>().Property(s => s.LaiSuatKyHan).HasPrecision(18, 2);
            modelBuilder.Entity<PhieuRutTien>().Property(p => p.SoTienRut).HasPrecision(18, 2);
            modelBuilder.Entity<PhieuGuiTien>().Property(p => p.SoTienGui).HasPrecision(18, 2);
            modelBuilder.Entity<BaoCaoThang>().Property(b => b.TongSoTienGui).HasPrecision(18, 2);
            modelBuilder.Entity<BaoCaoThang>().Property(b => b.TongSoTienRut).HasPrecision(18, 2);
            modelBuilder.Entity<SoTietKiem>().Property(s => s.LaiSuatApDung).HasPrecision(18, 2);

            modelBuilder.Entity<HinhThucDenHan>().HasData(
                new HinhThucDenHan() { MaHinhThucDenHan = 1, TenHinhThucDenHan = "Rút hết" },
                new HinhThucDenHan() { MaHinhThucDenHan = 2, TenHinhThucDenHan = "Quay vòng gốc" },
                new HinhThucDenHan() { MaHinhThucDenHan = 3, TenHinhThucDenHan = "Quay vòng cả gốc và lãi" }
            );

        }
    }
}
