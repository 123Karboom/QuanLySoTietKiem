using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLySoTietKiem.Models
{
    public class BaoCaoNgay
    {
        [Key]
        public int MaBaoCaoNgay { get; set; }

        [Required]
        public int MaLoaiSo { get; set; }
        public DateTime NgayGhi { get; set; }

        [Required]
        public decimal SoTienGui { get; set; }

        [ForeignKey("MaLoaiSo")]
        public virtual LoaiSoTietKiem LoaiSoTietKiem { get; set; }
    }
}
