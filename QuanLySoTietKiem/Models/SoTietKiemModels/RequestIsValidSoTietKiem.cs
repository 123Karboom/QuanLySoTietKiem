using System.ComponentModel.DataAnnotations;

namespace QuanLySoTietKiem.Models.SoTietKiemModels
{
  public class RequestIsValidSoTietKiem
  {
    [Required]
    public string userId { get; set; } = string.Empty;
    [Required]
    public int soTietKiemId { get; set; } = 0;
  }
}