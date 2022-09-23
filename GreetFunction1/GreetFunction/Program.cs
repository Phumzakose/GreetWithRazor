using Dapper;
using Npgsql;
using GreetFunction;

IGreet user = new GreetUsingDataBase();


Console.WriteLine("Welcome to the greetings App");
Console.WriteLine("Enter help for the available Commands");

string? userCommand = "";
int counter = 1;

string[] validCommands = { "greet username language", "greeted username", "greeted ", "counter", "clear", "exit", "help" };
string connectionString = "Server=tiny.db.elephantsql.com ;Port=5432;Database=znshpmlq;UserId=znshpmlq;Password=EMEIxMo2NpTDcz4rsKbgvUn2hyNqRJWi";
var connection = new NpgsqlConnection(connectionString);
connection.Open();

string CREATE_PEOPLE_TABLE = @"create table if not exists people (
  Id AUTO_INCREMENT primary key,
  FirstName varchar(50) NOT NULL,
  GreetedTimes int NOT NULL
);";

connection.Execute(CREATE_PEOPLE_TABLE);


while (userCommand != "exit")
{
  Console.WriteLine("****************************************************");
  Console.WriteLine(">Enter your Command:");

  userCommand = Console.ReadLine().ToLower();
  string[] command = userCommand.Trim().Split(" ");
  string userName = "";
  if (command.Length > 1)
  {
    userName = char.ToUpper(command[1][0]) + command[1].Substring(1);

  }
  if (command[0] == "greet" && command[1] != "" && command.Length == 3)
  {



    Console.WriteLine(user.GreetFriends(command));
    user.AddUsers(userName, counter);


  }
  else if (command[0] == "greet" && command.Length == 2)
  {
    command[1] = userName;
    Console.WriteLine(user.GreetFriends(command));
    user.AddUsers(userName, counter);
  }
  else if (userCommand == "greeted")
  {
    if (user.GetList().Count != 0)
    {
      foreach (KeyValuePair<string, int> kv in user.GetList())
      {
        Console.WriteLine(kv.Key + ":" + kv.Value);
      }
    }
    else
    {
      Console.WriteLine("You did not greet anyone");
    }

  }

  else if (command[0] == "greeted" && command[1] != "")
  {
    Console.WriteLine(user.GreetedTimes(userName));

  }
  else if (userCommand == "counter")
  {
    Console.WriteLine(user.Counter());

  }
  else if (userCommand == "clear")
  {
    Console.WriteLine(user.Clear());
  }
  else if (command[0] == "clear")
  {

    foreach (KeyValuePair<string, int> kv in user.GetList())
    {
      Console.WriteLine(user.Remove(userName));

    }
  }
  else if (userCommand == "help")
  {
    user.Help();
  }
  else if (!validCommands.Contains(userCommand))
  {
    Console.WriteLine("Invalid command");
  }
}