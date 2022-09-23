namespace GreetFunction;
public interface IGreet
{
  string Greetings(string firstName, string language);
  string GreetFriends(string[] command);
  void AddUsers(string userName, int counter);
  Dictionary<string, int> GetList();
  string GreetedTimes(string userName);
  int Counter();
  string Clear();
  string Remove(string userName);
  void Help();
  string Message();
}