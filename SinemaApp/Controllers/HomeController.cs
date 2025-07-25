using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.Models;

namespace SinemaApp.Controllers;

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

    public IActionResult Filmler()
    {
        return View();
    }

    public IActionResult Koltuklar()
    {
        return View();
    }
    public IActionResult Salonlar()
    {
        return View(); 
    }
    public IActionResult Biletler()
    {
        return View();
    }
    public IActionResult Admin()
    {
        return View();
    }

}
