using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetFunction;
using System.Text.RegularExpressions;

namespace GreetWithRazor.Pages;

public class IndexModel : PageModel
{
  //IGreet user = new GreetUsingDataBase();
  private IGreet _greetings;


  private readonly ILogger<IndexModel> _logger;

  public IndexModel(ILogger<IndexModel> logger, IGreet GreetUsingDatabase)
  {
    _logger = logger;
    _greetings = GreetUsingDatabase;
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
  }

  public Dictionary<string, int> List { get; set; }

  public string clear { get; set; }




  [BindProperty]
  public Greeter Greet { get; set; }
  [BindProperty]
  public string Handler { get; set; }


  static string pattern = @"^[a-zA-Z]*$";
  Regex reg = new Regex(pattern);

  public void OnPostGreet()
  {
    if (Handler == "Greet")
    {
      if (Greet.FirstName != null && Greet.Language != null)
      {
        if (reg.IsMatch(Greet.FirstName))
        {
          _greetings.AddUsers(Greet.FirstName, 1);
          Greeting = _greetings.Greetings(Greet.FirstName, Greet.Language);

        }
        else
        {
          Greeting = "Your name is invalid";

        }
        List = _greetings.GetList();
        Greet.FirstName = "";
        Greet.Language = "";
        ModelState.Clear();
      }
    }

  }
  public IActionResult OnPostClear()
  {
    if (Handler == "clear")
    {
      //clear = _greetings.Clear();
      List = _greetings.GetList();


    }
    return Redirect("/Greeted");


  }

  // public IActionResult OnPost()
  // {
  //   if (Action == "Greet")
  //   {
  //     if (ModelState.IsValid)
  //     {
  //       _greetings.AddUsers(Greet.FirstName, 1);
  //       List = _greetings.GetList();
  //       Greeting = _greetings.Greetings(Greet.FirstName, Greet.Language);
  //       Greet.FirstName = "";
  //       Greet.Language = "";
  //       ModelState.Clear();

  //     }

  //   }
  //   else if (Action == "clear")
  //   {
  //     if (Greet.FirstName == null && Greet.Language == null)
  //     {

  //       clear = _greetings.Clear();
  //     }

  //   }
  //   return Page();

  // }

}
