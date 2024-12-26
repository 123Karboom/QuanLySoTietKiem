using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySoTietKiem.Models
{
    public class SoTietKiemModel
    {
        public int MaSoTietKiem { get; set; }
        [Required]
        public string? Code { get; set; }
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }
        [Required]
        public int MaLoaiSo { get; set; }
        [Required]
        public int MaHinhThucDenHan { get; set; }
        public decimal SoDuSoTietKiem { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số tiền gửi phải lớn hơn 0")]
        public decimal SoTienGui { get; set; }
        public decimal LaiSuatKyHan { get; set; }
        public bool TrangThai { get; set; }
        public decimal LaiSuatApDung { get; set; }
        public DateTime NgayMoSo { get; set; }
        public DateTime NgayDongSo { get; set; }
    }
}