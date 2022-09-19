using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetFunction;

namespace GreetWithRazor.Pages;

public class IndexModel : PageModel
{
  //IGreet user = new GreetUsingDataBase();
  public IGreet _greetings { get; set; }

  private readonly ILogger<IndexModel> _logger;

  public IndexModel(ILogger<IndexModel> logger, IGreet GreetUsingDatabase)
  {
    _logger = logger;
    _greetings = GreetUsingDatabase;
  }


  public void OnGet()
  {

    // return Page();

  }

  public string? Greeting { get; set; }
  public int count { get; set; }
  public Dictionary<string, int> List { get; set; }

  public string clear { get; set; }




  [BindProperty]
  public Greeter Greet { get; set; }
  [BindProperty]
  public string Action { get; set; }



  public IActionResult OnPost()
  {
    if (Action == "Greet")
    {
      if (ModelState.IsValid)
      {
        _greetings.AddUsers(Greet.FirstName, 1);
        count = _greetings.Counter();
        List = _greetings.GetList();
        Greeting = _greetings.Greetings(Greet.FirstName, Greet.Language);
        Greet.FirstName = "";
        Greet.Language = "";
        ModelState.Clear();

      }


    }
    else if (Action == "clear")
    {
      if (Greet.FirstName == null && Greet.Language == null)
      {

        clear = _greetings.Clear();
      }

    }
    else if (Action == "remove")
    {
      _greetings.Remove(Greet.FirstName);
      Console.WriteLine(_greetings.Remove(Greet.FirstName));

    }
    return Page();

  }
}
