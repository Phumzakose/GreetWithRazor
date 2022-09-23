namespace GreetFunction;
public class Greet
{
  public string UserName { get; set; } = String.Empty;

  public string Language { get; set; } = String.Empty;

  private Dictionary<string, int> names = new Dictionary<string, int>();
  //public static string? userName = "";

  public static int counter = 1;

  public string Greetings(string language, string firstName)
  {

    if (firstName != null && language != null)
    {
      if (language == "setswana")
      {
        return "Dumelang, le kae? " + firstName;
      }
      else if (language == "isixhosa")
      {
        return "Molo, " + firstName;
      }
      else if (language == "isizulu")
      {
        return "Sawubona, " + firstName;
      }
      else
      {
        return "Please select a language, " + firstName;
      }
    }
    else if (language == "")
    {
      return "Hello, " + firstName;
    }
    return "";
  }


  public void AddUsers(string userName, int counter)
  {

    if (names.ContainsKey(userName))
    {
      names[userName]++;
    }
    else
    {
      names.Add(userName, counter);
    }
  }
  public Dictionary<string, int> GetList()
  {

    return names;

  }

  public string GreetedTimes(string userName)
  {


    foreach (KeyValuePair<string, int> kv in names)
    {
      if (names.ContainsKey(userName))
      {
        return userName + " was greeted " + names[userName] + " time/s";
      }
      else
      {
        return "This name was not greeted";
      }

    }
    return "";

  }
  public int Counter()
  {
    if (names.Count != 0)
    {
      return names.Count();
    }
    else
    {
      return 0;
    }
  }
  public string Clear()
  {

    names.Clear();
    return "Your list is cleared";
  }
  public string Remove(string userName)
  {

    if (names.ContainsKey(userName))
    {
      names.Remove(userName);
      return userName + " was removed";
    }
    return "";
  }
  public void Help()
  {
    Console.WriteLine(">To greet people enter greet, name and language");
    Console.WriteLine(">To see greeted people enter greeted");
    Console.WriteLine(">To check how many times a user was greeted enter greeted and name");
    Console.WriteLine(">To check how many people have been greeted enter counter");
    Console.WriteLine(">To remove someone in the list enter clear and the name");
    Console.WriteLine(">To delete all the people you have greeted enter clear");
    Console.WriteLine(">To exit the application enter exit");
  }
  public string Message()
  {
    return "Your list is cleared";
  }

}



