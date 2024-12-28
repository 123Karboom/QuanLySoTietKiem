using System.Diagnostics;
using QuanLySoTietKiem.Models;

namespace Helpers;
public static class DaoHanHelper
{

  public static void XuLyDaoHan(SoTietKiem soTietKiem, decimal tienLai)
  {
    Debug.WriteLine("MaHinhThucDenHan: " + soTietKiem.MaHinhThucDenHan);
    switch (soTietKiem.MaHinhThucDenHan)
    {
      case 1: // Rút hết
        RutHet(soTietKiem);
        break;
      case 2: // Quay vòng gốc
        QuayVongGoc(soTietKiem, tienLai);
        break;
      case 3: // Quay vòng cả gốc và lãi
        QuayVongGocVaLai(soTietKiem, tienLai);
        break;
      default:
        throw new ArgumentException("Hình thức đáo hạn không hợp lệ");
    }
  }
  private static void RutHet(SoTietKiem soTietKiem)
  {
    Debug.WriteLine("=>>>>>>>>>>>>>>>>>>>>>Rút hết");
    //Đóng sổ 
    soTietKiem.TrangThai = false; // Trạng thái sổ tiết kiệm đã được đóng
    soTietKiem.NgayDongSo = DateTime.Now; //Ngày đóng sổ 
    soTietKiem.SoDuSoTietKiem = 0; // Số dư sổ tiết kiệm rút hết
  }
  private static void QuayVongGoc(SoTietKiem soTietKiem, decimal tienLai)
  {
    Debug.WriteLine("=>>>>>>>>>>>>>>>>>>>>>Quay vòng gốc");

    // Tạo kỳ hạn mới với số tiền gốc ban đầu
    soTietKiem.NgayMoSo = DateTime.Now;
    soTietKiem.NgayDaoHan = soTietKiem.NgayMoSo.AddMonths(soTietKiem.LoaiSoTietKiem.KyHan);
    // Số dư = số tiền gốc (tiền lãi được rút ra)
    soTietKiem.SoDuSoTietKiem = soTietKiem.SoTienGui;
  }

  private static void QuayVongGocVaLai(SoTietKiem soTietKiem, decimal tienLai)
  {
    Debug.WriteLine("=>>>>>>>>>>>>>>>>>>>>>Quay vòng gốc và lãi");

    //Tạo kỳ hạn mới
    soTietKiem.NgayMoSo = DateTime.Now;
    soTietKiem.NgayDaoHan = soTietKiem.NgayMoSo.AddMonths(soTietKiem.LoaiSoTietKiem.KyHan);
    //Số dư = gốc + lãi 
    soTietKiem.SoDuSoTietKiem += tienLai;
    soTietKiem.SoTienGui = soTietKiem.SoDuSoTietKiem;
  }
}