using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Galodex.Models;
using System.Text.Json;

namespace Galodex.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
       List<Pokemon> pokemons = [];
       using (StreamReader leitor = new("Data\\pokemons.json"))
       {
        string dados = leitor.ReadToEnd();
        pokemons = JsonSerializer.Deserialize<List<Pokemon>>(dados);
       }
       return View(pokemons);
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
