using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HerramientasProgFinal.Models;
using Microsoft.AspNetCore.Authorization;

namespace HerramientasProgFinal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }
    [Authorize]
    public IActionResult Index()
    {
        if (User.IsInRole("AdminSupremo") || User.IsInRole("AdminSupremo"))
        {
            // User is in the "admin" or "ADMIN" role
            return View();
        }

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
