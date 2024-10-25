using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab3.Models;
using System.Linq;

namespace lab3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class LecturerController : Controller
{
    private readonly UniversityContext _context;

    public LecturerController(UniversityContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var lecturers = _context.Lecturer.ToList();
        return View(lecturers);
    }
}
