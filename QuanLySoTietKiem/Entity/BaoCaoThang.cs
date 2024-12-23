using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLySoTietKiem.Models
{
    public class BaoCaoThang
    {
        [Key]
        public int MaBaoCaoThang { get; set; }

        [Required]
        public int MaLoaiSo { get; set; }
        public string Thang { get; set; }

        [Required]
        public int SoLuongDong { get; set; }
        public decimal SoTienGui { get; set; }
        public decimal ChenhLech { get; set; }

        [ForeignKey("MaLoaiSo")]
        public virtual LoaiSoTietKiem LoaiSoTietKiem { get; set; }
    }
}
