using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;
using GreetFunction;
using System.Text.RegularExpressions;

namespace GreetWithRazor.Pages;

public class IndexModel : PageModel
{

  private IGreet _greetings;
  private readonly ILogger<IndexModel> _logger;

  public IndexModel(ILogger<IndexModel> logger, IGreet GreetWithMongo)
  {
    _logger = logger;
    _greetings = GreetWithMongo;
  }



  public void OnGet()
  {

  }
  public string? Greeting { get; set; }
  public int count
  {
    get
    {
      return _greetings.Counter();
    }
    // get; set;
  }

  public Dictionary<string, int> List { get; set; }

  public string clear { get; set; }




  [BindProperty]
  public Greeter Greet { get; set; }
  [BindProperty]
  public string Handler { get; set; }


  public void OnPostGreet()
  {
    if (Handler == "Greet")
    {
      if (ModelState.IsValid)
      {

        _greetings.AddUsers(Greet.FirstName, 1);
        Greeting = _greetings.Greetings(Greet.FirstName, Greet.Language);
        List = _greetings.GetList();
        _greetings.Counter();
        Greet.FirstName = "";
        Greet.Language = "";
        ModelState.Clear();
      }

    }

  }
  public IActionResult OnPostGreetedPeople()
  {
    if (Handler == "greetedPeople")
    {

      List = _greetings.GetList();

    }
    return Redirect("/Greeted");


  }


}
