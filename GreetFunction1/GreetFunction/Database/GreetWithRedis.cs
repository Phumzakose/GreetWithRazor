namespace GreetFunction;
using StackExchange.Redis;


public class GreetWithRedis : IGreet
{
  private IDatabase FriendsData;
  public GreetWithRedis()
  {
    ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");
    FriendsData = connection.GetDatabase();
  }

  public string Greetings(string firstName, string language)
  {
    firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);

    if (firstName != "" && language != "")
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
        return language + " is not recognised";
      }

    }
    else if (language == "")
    {
      return "Hello, " + firstName;
    }
    return "";
  }
  public string GreetFriends(string[] command)
  {
    if (command[0] == "greet" && command.Length == 3)
    {
      if (command[2] == "setswana" && command[0] == "greet")
      {
        return "Dumelang, le kae? " + command[1];
      }
      else if (command[2] == "isixhosa" && command[0] == "greet")
      {
        return "Molo, " + command[1];
      }
      else if (command[2] == "isizulu" && command[0] == "greet")
      {
        return "Sawubona, " + command[1];
      }
      else
      {
        return command[2] + " is not recognised";
      }
    }
    else if (command[0] == "greet" && command.Length == 2)
    {
      return "Hello, " + command[1];
    }
    return "";
  }
  public void AddUsers(string userName, int counter)
  {
    userName = userName[0].ToString().ToUpper() + userName.Substring(1);
    if (FriendsData.HashExists("People", userName))
    {
      int num = Convert.ToInt32(FriendsData.HashGet("Friend", userName)) + 1;

      FriendsData.HashSet("People", new HashEntry[] { new HashEntry(userName, num) });
    }
    else
    {
      FriendsData.HashSet("People", new HashEntry[] { new HashEntry(userName, counter) });
    }

  }

  public Dictionary<string, int> GetList()
  {
    var names = new Dictionary<string, int>();

    foreach (var item in FriendsData.HashGetAll("People"))
    {
      int val = Convert.ToInt32(item.Value);
      names.Add(item.Name!, val);
    }

    return names;

  }
  public string GreetedTimes(string userName)
  {

    foreach (var item in GetList())
    {
      if (FriendsData.HashExists("People", userName))
      {
        return userName + " was greeted " + FriendsData.HashGet("People", userName);
      }
      else
      {
        return userName + " was not greeted";

      }
    }
    return "";
  }
  public int Counter()
  {
    int result = Convert.ToInt32(FriendsData.HashLength("People"));
    return result;

  }
  public string Clear()
  {
    if (FriendsData.HashLength("People") > 0)
    {
      foreach (var item in GetList())
      {
        FriendsData.HashDelete("People", item.Key);
      }
      return "Your list is cleared";
    }
    else
    {
      return "Your list is empty you did not greet anyone";
    }
  }
  public string Remove(string userName)
  {
    FriendsData.HashDelete("People", userName);
    return userName + " was removed";

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
    return "Your list is cleared!";
  }


}