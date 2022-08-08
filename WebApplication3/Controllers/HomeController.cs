using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var client = new HttpClient();
        var kanye = new KanyeResponse();
        var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
        var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
        kanye.Response = kanyeQuote;
        return View(kanye);
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
