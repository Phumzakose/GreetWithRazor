using System.ComponentModel.DataAnnotations;
namespace GreetWithMvc.Models;

public class GreetModel
{
  public int Counter { get; set; }

  [Required(ErrorMessage = "Please enter a your name")]
  [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid name characters are not allowed")]
  public string? FirstName { get; set; }
  [Required(ErrorMessage = "Please select a language")]
  public string? Language { get; set; }


}
