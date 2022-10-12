using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.Services;

namespace MvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICodeWordService _codeWordService;

    public HomeController(ILogger<HomeController> logger, ICodeWordService codeWordService)
    {
        _logger = logger;
        _codeWordService = codeWordService;
    }

    public IActionResult Index()
    {
        return View(new IndexViewModel { CodeWord = _codeWordService.GetWord() });
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
