using MongoDB.Bson;
using MongoDB.Driver;
namespace GreetFunction.Database;

public class GreetWithMongo : IGreet
{
  private IMongoCollection<Friends> collection;

  public GreetWithMongo(string connectionString)
  {
    var client = new MongoClient(connectionString);
    var database = client.GetDatabase("friends");
    collection = database.GetCollection<Friends>("greet");

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
    var item = collection.Find(x => x.FirstName == userName).CountDocuments();
    var na = collection.Find(x => x.FirstName == userName).FirstOrDefault();

    if (item == 1)
    {
      na.Counter = Convert.ToInt32(item + 1);
      collection.ReplaceOne(x => x.FirstName == userName, na);
    }
    else
    {
      userName = userName[0].ToString().ToUpper() + userName.Substring(1);

      Friends doc = new Friends()
      {

        FirstName = userName,
        Counter = counter

      };
      collection.InsertOne(doc);
    }
  }
  public Dictionary<string, int> GetList()
  {

    var names = new Dictionary<string, int>();

    var doc = new BsonDocument();
    foreach (var item in collection.Find(doc).ToList())
    {

      names.Add(item.FirstName, item.Counter);
    }

    return names;

  }
  public string GreetedTimes(string userName)
  {
    var names = new Dictionary<string, int>();
    foreach (var item in collection.Find(new BsonDocument()).ToList())
    {
      names.Add(item.FirstName, item.Counter);
    }
    if (names.ContainsKey(userName))
    {
      return userName + " was greeted " + GetList()[userName] + " time/s";
    }
    else
    {
      return "This name was not greeted";
    }

  }
  public int Counter()
  {
    var names = new Dictionary<string, int>();
    foreach (var item in collection.Find(new BsonDocument()).ToList())
    {
      names.Add(item.FirstName, item.Counter);
    }
    return names.Count();

  }
  public string Clear()
  {
    collection.DeleteMany(new BsonDocument());
    return "Your list is cleared";
  }
  public string Remove(string userName)
  {

    collection.DeleteOne(x => x.FirstName == userName);
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
