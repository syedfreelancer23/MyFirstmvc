
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyFirstmvc.Models;

namespace MyFirstmvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model=new List<Customer>();
        model.Add(new Customer
        {
            Name="syed",
            SurName="ssyed",
            DateOfBirth=new DateOnly(1960, 5, 5)
        });
        model.Add(new Customer
        {
            Name="syed",
            SurName="ssyed",
            DateOfBirth=new DateOnly(1960, 5, 5)
        });
        return View("Index",model);
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
