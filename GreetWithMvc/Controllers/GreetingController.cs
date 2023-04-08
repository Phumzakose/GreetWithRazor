using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GreetWithMvc.Models;
using GreetFunction;
using GreetFunction.Database;

namespace GreetWithMvc.Controllers;

public class HomeController : Controller
{
  private IGreet _greetings;
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger, IGreet GreetUsingDatabase)
  {
    _logger = logger;
    _greetings = GreetUsingDatabase;
  }

  public IActionResult Index()
  {
    ViewData["count"] = _greetings.Counter();

    return View();
  }

  [HttpPost]

  public IActionResult Greetings(GreetModel friends)
  {
    if (ModelState.IsValid)
    {
      _greetings.AddUsers(friends.FirstName!.ToUpper(), 1);
      ViewData["Greeting"] = _greetings.Greetings(friends.FirstName!.ToUpper(), friends.Language!);
      ViewData["list"] = _greetings.GetList();
      ViewData["count"] = _greetings.Counter();
      friends.FirstName = "";
      friends.Language = "";
      ModelState.Clear();



    }
    return View("Index");

  }

  [HttpPost]
  public IActionResult List()
  {
    ViewData["list"] = _greetings.GetList();
    return View();
  }

  public IActionResult Clear()
  {
    _greetings.Clear();
    ViewData["list"] = _greetings.GetList();
    ViewData["Message"] = _greetings.Message();
    return View("List");

  }
  public IActionResult Remove(GreetModel friends)
  {
    _greetings.Remove(friends.FirstName!);
    ViewData["list"] = _greetings.GetList();

    return View("List");
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
