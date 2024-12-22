using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLySoTietKiem.Models
{
    public class PhieuGuiTien
    {
        [Key]
        public int MaPhieuGui { get; set; }

        [Required]
        public int MaSoTietKiem { get; set; }
        public DateTime NgayGui { get; set; }
        public decimal SoTienGui { get; set; }

        [ForeignKey("MaSoTietKiem")]
        public virtual SoTietKiem SoTietKiem { get; set; }
    }
}
