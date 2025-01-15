using Microsoft.EntityFrameworkCore;
using QuanLySoTietKiem.Data;
using QuanLySoTietKiem.Models.SoTietKiemModels;
using QuanLySoTietKiem.Services.Interfaces;

namespace QuanLySoTietKiem.Services
{
  public class SoTietKiemService : ISoTietKiemService
  {
    private readonly ApplicationDbContext _context;
    public SoTietKiemService(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<int> CountSoTietKiem(string userId)
    {
      var count = await _context.SoTietKiems.Where(s => s.UserId == userId).CountAsync();
      return count;
    }
    public async Task<string> GetCodeSTK(string userId, int maSoTietKiem)
    {
      return await _context.SoTietKiems
        .Where(s => s.UserId == userId && s.MaSoTietKiem == maSoTietKiem)
        .Select(s => s.Code)
        .FirstOrDefaultAsync() ?? string.Empty;
    }
    public async Task<double> GetSoDuSoTietKiemByCodeSTK(string userId, string CodeSTK)
    {
      var soDuSoTietKiem = await _context.SoTietKiems.Where(s => s.UserId == userId && s.Code == CodeSTK).Select(s => s.SoDuSoTietKiem).FirstOrDefaultAsync();
      return (double)soDuSoTietKiem;
    }
    public async Task<bool> IsSoTietKiemValid(RequestIsValidSoTietKiem request)
    {
      var accountSavings = await _context.SoTietKiems.Where(s => s.UserId == request.userId && s.MaSoTietKiem == request.soTietKiemId && s.TrangThai == true).FirstOrDefaultAsync();
      if (accountSavings == null)
      {
        return false;
      }
      return true;
    }

    public async Task<bool> IsSavingAccountActiveByUserId(string userId)
    {
      var accountSavings = await _context.SoTietKiems.Where(s => s.UserId == userId && s.TrangThai == true).FirstOrDefaultAsync();
      if (accountSavings == null)
      {
        return false;
      }
      return true;
    }

  }
}