using System.ComponentModel.DataAnnotations;

namespace Models.RutTien;
public class WithdrawMoneyViewModel
{
  public int MaSoTietKiem { get; set; }
  public string? Code { get; set; }
  public decimal SoDuHienTai { get; set; }
  public DateTime NgayMoSo { get; set; }
  public DateTime NgayDaoHan { get; set; }
  public decimal LaiSuatKyHan { get; set; }
  public bool TrangThai { get; set; }

  [Required(ErrorMessage = "Vui lòng nhập số tiền muốn rút")]
  [Range(100000, double.MaxValue, ErrorMessage = "Số tiền rút tối thiểu là 100,000 VNĐ")]
  public decimal SoTienRut { get; set; }
}
