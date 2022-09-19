using System.ComponentModel.DataAnnotations;
using GreetFunction;
using GreetWithRazor.Pages;
public class Greeter
{
  public int Id { get; set; }

  [Required, StringLength(10)]
  public string? FirstName { get; set; }
  [Required]
  public string? Language { get; set; }

  // public Dictionary<string, int> Greeting
  // {
  //   get
  //   {
  //     return user.GetList();

  //   }
  // }

}





