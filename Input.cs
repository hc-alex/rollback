using System.Collections.Generic;
using Test.Banks;
using Test.Commands;

namespace Test
{
  public class Input
  {
    private readonly CurrentState _currentState;

    private readonly Dictionary<string, Command> _preparedCommands;
    private readonly EmptyCommand _emptyCommand;

    public Input(Bank bank, ConsoleMessage message)
    {
      _currentState = new CurrentState();
      
      _preparedCommands = new Dictionary<string, Command>
      {
        ["accounts"] = new GetAccountsCommand(bank, _currentState, message),
        ["open"] = new OpenAccountCommand(bank, _currentState, message),
        ["transfer"] = new TransferCommand(bank, _currentState, message),
        ["close"] = new CloseAccountCommand(bank, _currentState, message),
        ["undo"] = new UndoCommand(bank, _currentState, message),
        ["abort"] = new AbortCommand(bank, _currentState, message)
      };

      _emptyCommand = new EmptyCommand(bank, _currentState, message);
    }

    public void Handle(string input)
    {
      _currentState.UserInput = input;

      Command command = GetCommand(input);
      
      if (_currentState.CurrentCommand == null || command is AbortCommand)
        command.Execute();
      else
        _currentState.CurrentCommand.Execute();
    }

    private Command GetCommand(string key) => 
      _preparedCommands.ContainsKey(key) ? _preparedCommands[key] : _emptyCommand;
  }
}