using System;
using Test.Banks;

namespace Test
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Bank bank = new Bank();
      ConsoleMessage message = new ConsoleMessage();
      Input input = new Input(bank, message);

      while (true)
      {
        Console.WriteLine(message.Text);
        string command = Console.ReadLine();

        if (command == "exit")
          break;
        
        input.Handle(command);
      }
    }
  }
}    
 
