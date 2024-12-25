using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySoTietKiem.Models
{
    public class SoTietKiemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Range(100000, double.MaxValue, ErrorMessage = "Số tiền gửi tối thiểu là 100,000 VNĐ")]
        [Display(Name = "Số tiền gửi")]
        public decimal SoTienGui { get; set; }

        [Required]
        [Display(Name = "Kỳ hạn")]
        public int KyHan { get; set; } // Tháng

        [Required]
        [Display(Name = "Ngày mở sổ")]
        public DateTime NgayMoSo { get; set; }

        [Display(Name = "Lãi suất")]
        public double LaiSuat { get; set; }
        [Display(Name = "Loại sổ tiết kiệm")]
        public string LoaiSoTietKiem { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}