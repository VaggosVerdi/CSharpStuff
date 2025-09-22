using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharpStuff.Models;

namespace CSharpStuff.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public FrequentItemViewModel FindMostFrequentItem(string[] data)
    {
        var freq = new Dictionary<string, int>();
        foreach (var item in data)
        {
            if (freq.ContainsKey(item))
            {
                freq[item]++;
            }
            else
            {
                freq[item] = 1;
            }
        }
        int max = freq.Values.Max();
        var sel = freq.Where(x => x.Value == max).Select(x => x.Key).ToList();
        return new FrequentItemViewModel { Names = sel, Count = max };
    }

    public IActionResult Index()
    {
        string[] data = { "Apple", "Banana", "Cherry", "Apple", "Date", "Banana", "Elderberry" };
        var result = FindMostFrequentItem(data);
        ViewBag.Name = string.Join(", ", result.Names);
        ViewBag.Count = result.Count;
        return View();
    }

    public IActionResult RectangleAPC()
    {
        return View();
    }

    public IActionResult EvenSumCalc()
    {
        return View();
    }

    public IActionResult WordReversal()
    {
        return View();
    }

    public IActionResult TimeChecker()
    {
        return View();
    }

    public IActionResult CommonString()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
