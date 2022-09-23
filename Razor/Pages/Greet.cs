using System.ComponentModel.DataAnnotations;
using GreetFunction;
using GreetWithRazor.Pages;
public class Greeter
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Please enter your name")]
  [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
  public string? FirstName { get; set; }
  [Required(ErrorMessage = "Please select a language")]
  public string? Language { get; set; }


}





