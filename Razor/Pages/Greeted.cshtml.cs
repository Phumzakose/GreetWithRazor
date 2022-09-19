using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetFunction;

namespace GreetWithRazor.Pages;


public class GreetedModel : PageModel
{

  public IGreet _greetings;
  private readonly ILogger<IndexModel> _logger;

  public GreetedModel(ILogger<IndexModel> logger, IGreet GreetUsingDatabase)
  {
    _logger = logger;
    _greetings = GreetUsingDatabase;
  }
  public Dictionary<string, int> List
  {
    // get
    // {
    //   return _greetings.GetList();
    // }
    get;
    set;

  }
  [BindProperty]
  public Greeter Greet { get; set; }
  [BindProperty]
  public string Action { get; set; }


  public void OnGet()
  {

    List = _greetings.GetList();


  }
  public IActionResult OnPost()
  {
    if (Action == "remove")
    {
      foreach (KeyValuePair<string, int> kv in _greetings.GetList())
      {
        _greetings.Remove(Greet.FirstName);
        Greet.FirstName = "";
        ModelState.Clear();

      }

    }
    return Page();
  }

}

