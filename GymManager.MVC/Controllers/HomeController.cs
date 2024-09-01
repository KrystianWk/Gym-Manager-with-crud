using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GymManager.MVC.Models;

namespace GymManager.MVC.Controllers;

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
    public IActionResult NoAccess()
    {
        return View();
    }   

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult About()
    {
        var model = new About()
        {
            Title = "GymManagmentSystem",
            Description = "use it to manage gym",
            Tags = new List<string> { "trainer", "trainee" }
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
