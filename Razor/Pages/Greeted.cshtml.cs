using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetFunction;

namespace GreetWithRazor.Pages;


public class GreetedModel : PageModel
{

  private IGreet _greetings;
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
  public string Message
  {
    // get
    // {
    //   return _greetings.Message();
    // }
    get;
    set;
  }
  [BindProperty]
  public Greeter Greet { get; set; }

  [BindProperty]
  public string Handler { get; set; }

  public void OnGet()
  {

    List = _greetings.GetList();
    //Message = _greetings.Message();


  }
  public void OnPostRemove(string name)
  {

    _greetings.Remove(Greet.FirstName);
    Greet.FirstName = "";
    ModelState.Clear();
    List = _greetings.GetList();


  }

  public void OnPostClear(string name)
  {
    if (Handler == "clear")
    {
      _greetings.Clear();
      List = _greetings.GetList();
      Message = _greetings.Message();


    }

  }


}

