using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreetWithRazor.Pages;

public class GuideUserModel : PageModel
{
  private readonly ILogger<GuideUserModel> _logger;

  public GuideUserModel(ILogger<GuideUserModel> logger)
  {
    _logger = logger;
  }

  [BindProperty]
  public string Action { get; set; }

  public void OnGet()
  {
  }

  public IActionResult OnPostContinue()
  {
    return Redirect("/Index");

  }
}

