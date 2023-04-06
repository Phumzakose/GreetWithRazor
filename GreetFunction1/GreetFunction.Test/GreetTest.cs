namespace GreetFunction.Test;
using Npgsql;
using Dapper;
using GreetFunction.Database;
public class GreetTest
{
  static string connectionString = "Server=tiny.db.elephantsql.com ;Port=5432;Database=rjyxyjew;UserId=rjyxyjew;Password=T0xPrO3GmqOjoDyeCqz8q7H6FfmagVA8";

  static string GetConnectionString()
  {
    var theCN = Environment.GetEnvironmentVariable("connectionString");
    if (theCN == "" || theCN == null)
    {
      theCN = connectionString;
    }
    return theCN;
  }
  // IGreet user = new GreetWithMongo("mongodb://0.0.0.0:27017");
  IGreet user = new GreetUsingDataBase(GetConnectionString());

  public GreetTest()
  {
    // ensure all the waiters are in the database

    // run the database script in the remote database

    var sql = File.ReadAllText("./sql/data.sql");

    // Console.WriteLine(sql);

    using (var connection = new NpgsqlConnection(GetConnectionString()))
    {
      connection.Execute(sql);
    }

  }

  [Fact]
  public void ItShouldbeAbleToGreetUserWithIsiXhosa()
  {
    Assert.Equal("Molo, Phumza", user.Greetings("Phumza", "isixhosa"));

  }
  [Fact]
  public void ItShouldbeAbleToGreetUserWithSetswana()
  {
    Assert.Equal("Dumelang, le kae? Thembi", user.Greetings("Thembi", "setswana"));
  }
  [Fact]
  public void ItShouldbeAbleToGreetUserWithIsizulu()
  {
    Assert.Equal("Sawubona, Lukho", user.Greetings("Lukho", "isizulu"));
  }
  // [Fact]
  // public void ItShouldbeAbleToGreetUserWithEnglishIfNoLanguageIsEntered()
  // {
  //   Assert.Equal("Hello, Zikho", user.Greetings("Zikho", ""));
  // }
  // [Fact]
  // public void ItShouldbeAbleToReturnErrorMesssage()
  // {
  //   Assert.Equal("sepedi is not recognised", user.Greetings("Zikho", "sepedi"));
  // }
  [Fact]
  public void ItShouldBeAbleToReturnTheListOfPeopleGreeted()
  {
    user.AddUsers("Lulo", 1);
    user.AddUsers("Lulo", 1);
    user.AddUsers("Phumza", 1);
    user.AddUsers("Lakhe", 1);


    Dictionary<string, int> greeted = new Dictionary<string, int>() { { "Lulo", 2 }, { "Phumza", 1 }, { "Lakhe", 1 } };
    Assert.Equal(greeted, user.GetList());

    user.AddUsers("Phumza", 1);
    user.AddUsers("Lakhe", 1);
    Dictionary<string, int> names = new Dictionary<string, int>() { { "Lulo", 2 }, { "Phumza", 2 }, { "Lakhe", 2 } };
    Assert.Equal(names, user.GetList());

  }
  [Fact]
  public void ItShouldBeAbleToReturnHowManyTimesTheUserWasGreeted()
  {
    user.AddUsers("Lulo", 1);
    user.AddUsers("Lulo", 1);
    Dictionary<string, int> names = new Dictionary<string, int>() { { "Lulo", 2 } };
    Assert.Equal("Lulo was greeted 2 time/s", user.GreetedTimes("Lulo"));

  }
  [Fact]
  public void ItShouldBeAbleToReturnErrorMessageIfTheUserDoesNotExist()
  {
    user.AddUsers("Lulo", 1);
    user.AddUsers("Lulo", 1);

    Assert.Equal("This name was not greeted", user.GreetedTimes("Thuso"));

  }

  [Fact]
  public void ItShouldBeAbleToReturnTheNumberOfUsersGreeted()
  {
    //user.AddUsers("Lulo", 1);
    user.AddUsers("Lulo", 1);
    user.AddUsers("Phumza", 1);
    user.AddUsers("Lakhe", 1);

    Assert.Equal(3, user.Counter());

  }
  [Fact]
  public void ItShouldBeAbleToReturnErrorMessageIfThereAreNoUsersGreeted()
  {
    //Dictionary<string, int> names = new Dictionary<string, int>() { };
    foreach (var item in user.GetList())
    {
      Console.WriteLine(item);

    }
    user.Clear();
    Assert.Equal(0, user.Counter());

  }
  [Fact]
  public void ItShouldBeAbleToClearAllThePeopleInTheList()
  {
    user.AddUsers("Lulo", 1);
    user.AddUsers("Phumza", 1);
    user.AddUsers("Lakhe", 1);

    Assert.Equal("Your list is cleared", user.Clear());

  }
  [Fact]
  public void ItShouldBeAbleToRemoveOnePersonFromTheList()
  {
    user.AddUsers("Lulo", 1);
    user.AddUsers("Phumza", 1);
    user.AddUsers("Lakhe", 1);

    Assert.Equal("Phumza was removed", user.Remove("Phumza"));

  }


}