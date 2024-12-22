using System.ComponentModel.DataAnnotations;

namespace QuanLySoTietKiem.Models
{
    public class LoaiSoTietKiem
    {
        [Key]
        public int MaLoaiSo { get; set; }

        [Required]
        public string TenLoaiSo { get; set; }
        public float LaiSuat { get; set; }
        public int KyHan { get; set; }
        public int ThoiGianGuiToiThieu { get; set; }
        public decimal SoTienGuiToiThieu { get; set; }

        public virtual ICollection<BaoCaoNgay> BaoCaoNgays { get; set; }
        public virtual ICollection<BaoCaoThang> BaoCaoThangs { get; set; }
        public virtual ICollection<SoTietKiem> SoTietKiems { get; set; }
    }
}
