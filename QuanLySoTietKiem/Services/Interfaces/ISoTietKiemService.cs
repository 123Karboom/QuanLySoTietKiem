namespace QuanLySoTietKiem.Services.Interfaces
{
    public interface ISoTietKiemService
    {
        public Task<int> CountSoTietKiem(string userId);
        public Task<string> GetCodeSTK(string userId, int maSoTietKiem);
    }
}