public class SoTietKiemDetailModel
{
  public int MaSoTietKiem { get; set; }
  public string Code { get; set; }
  public decimal SoTienGui { get; set; }
  public decimal SoDuSoTietKiem { get; set; }
  public decimal LaiSuatApDung { get; set; }
  public decimal LaiSuatKyHan { get; set; }
  public DateTime NgayMoSo { get; set; }
  public DateTime? NgayDongSo { get; set; }
  public bool TrangThai { get; set; }

  // Related data
  public string TenLoaiSo { get; set; }
  public int KyHan { get; set; }
  public string TenHinhThucDenHan { get; set; }
  public string TenKhachHang { get; set; }
}