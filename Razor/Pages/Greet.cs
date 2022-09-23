using System.ComponentModel.DataAnnotations;
using GreetFunction;
using GreetWithRazor.Pages;
public class Greeter
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Please enter a your name")]
  [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid name characters are not allowed")]
  public string? FirstName { get; set; }
  [Required(ErrorMessage = "Please select a language")]
  public string? Language { get; set; }


}





