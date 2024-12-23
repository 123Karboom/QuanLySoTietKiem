using Microsoft.AspNetCore.Identity;
using QuanLySoTietKiem.Data;
using QuanLySoTietKiem.Models;
using QuanLySoTietKiem.Services.Interfaces;

namespace QuanLySoTietKiem.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public AccountService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


       
    }
}
