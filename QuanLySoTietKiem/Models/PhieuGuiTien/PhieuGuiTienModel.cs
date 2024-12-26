using System.ComponentModel.DataAnnotations;

namespace QuanLySoTietKiem.Models
{
  public class PhieuGuiTienModel
  {
    [Key]
    public int MaPhieuGui { get; set; }

    [Required]
    public int MaSoTietKiem { get; set; }
    [Required]
    public DateTime NgayGui { get; set; }
    [Required]
    public decimal SoTienGui { get; set; }
  }
}
