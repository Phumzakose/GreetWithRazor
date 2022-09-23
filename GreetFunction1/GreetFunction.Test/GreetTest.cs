
namespace GreetFunction.Test;
public class GreetTest
{
  Greet user = new Greet();

  [Fact]
  public void ItShouldbeAbleToGreetUserWithIsiXhosa()
  {
    Assert.Equal("Molo, Phumza", user.Greetings("isixhosa", "Phumza"));

  }
  [Fact]
  public void ItShouldbeAbleToGreetUserWithSetswana()
  {
    Assert.Equal("Dumelang, le kae? Thembi", user.Greetings("setswana", "Thembi"));
  }
  [Fact]
  public void ItShouldbeAbleToGreetUserWithIsizulu()
  {
    Assert.Equal("Sawubona, Lukho", user.Greetings("isizulu", "Lukho"));
  }
  [Fact]
  public void ItShouldbeAbleToGreetUserWithEnglishIfNoLanguageIsEntered()
  {
    Assert.Equal("Please select a language, Zikho", user.Greetings("", "Zikho"));
  }
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
    Dictionary<string, int> names = new Dictionary<string, int>() { };
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