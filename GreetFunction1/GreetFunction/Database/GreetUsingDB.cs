using Dapper;
using Npgsql;
namespace GreetFunction.Database;


public class GreetUsingDataBase : IGreet
{
  string connectionString = "Server=tiny.db.elephantsql.com ;Port=5432;Database=znshpmlq;UserId=znshpmlq;Password=EMEIxMo2NpTDcz4rsKbgvUn2hyNqRJWi";

  public void Table()
  {
    var connection = new NpgsqlConnection(connectionString);
    connection.Open();

  }
  public string Greetings(string firstName, string language)
  {
    firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);

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

    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();

    var parameters = new { UserName = userName };

    var sql = @"select count (*) from people where firstname = @UserName;";
    var result = connection.QueryFirst(sql, parameters);
    if (result.count == 1)
    {
      connection.Query<People>(@"UPDATE people SET greetedtimes = greetedtimes + 1 WHERE firstname= @UserName", parameters);
    }
    else
    {
      connection.Execute(@"
    insert into 
    people (FirstName, GreetedTimes)
    values 
    (@FirstName, @GreetedTimes);",
  new People()
  {
    FirstName = userName,
    GreetedTimes = counter

  });
      connection.Close();
    }



  }
  public Dictionary<string, int> GetList()
  {
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();
    Dictionary<string, int> names = new Dictionary<string, int>();

    var list = connection.Query<People>(@"select * from people order by firstname");
    foreach (var friends in list)
    {
      names.Add(friends.FirstName, friends.GreetedTimes);
    }

    return names;

  }
  public string GreetedTimes(string userName)
  {
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();
    Dictionary<string, int> names = new Dictionary<string, int>();

    var list = connection.Query<People>(@"select * from people");
    foreach (var friends in list)
    {
      names.Add(friends.FirstName, friends.GreetedTimes);
    }

    foreach (KeyValuePair<string, int> kv in names)
    {
      if (names.ContainsKey(userName))
      {
        return userName + " was greeted " + GetList()[userName] + " time/s";
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
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();
    Dictionary<string, int> names = new Dictionary<string, int>();

    var list = connection.Query<People>(@"select * from people");
    foreach (var friends in list)
    {
      names.Add(friends.FirstName, friends.GreetedTimes);
    }
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
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();

    var list = connection.Query<People>(@"delete from people");
    return "Your list is cleared";
  }
  public string Remove(string userName)
  {
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();

    var parameters = new { UserName = userName };
    var sql = @"DELETE from people where firstname = @UserName";
    var list = connection.Query<People>(sql, parameters);

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