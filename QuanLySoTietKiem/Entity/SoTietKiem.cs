using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuanLySoTietKiem.Models
{
    public class SoTietKiem
    {
        [Key]
        public int MaSoTietKiem { get; set; }

        [Required]
        public int MaLoaiSo { get; set; }
        public decimal SoDuSoTietKiem { get; set; }
        public bool TrangThai { get; set; }
        public float LaiSuatApDung { get; set; }
        public DateTime NgayMoSo { get; set; }
        public DateTime NgayDongSo { get; set; }
        [Required]
        public string UserId { get; set; }

        [ForeignKey("MaLoaiSo")]
        public virtual LoaiSoTietKiem LoaiSoTietKiem { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<PhieuRutTien> PhieuRutTiens { get; set; }
        public virtual ICollection<PhieuGuiTien> PhieuGuiTiens { get; set; }


    }
}
