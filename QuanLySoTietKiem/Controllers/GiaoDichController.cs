using Microsoft.AspNetCore.Mvc;
using QuanLySoTietKiem.Services.Interfaces;

namespace QuanLySoTietKiem.Controllers;

public class GiaoDichController : Controller
{
    private readonly IGiaoDichService _giaoDichService;
    public GiaoDichController(IGiaoDichService giaoDichService)
    {
        _giaoDichService = giaoDichService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}