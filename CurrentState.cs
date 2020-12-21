using System.Collections.Generic;
using Test.Commands;

namespace Test
{
  public class CurrentState
  {
    public Command CurrentCommand { get; private set; }
    public string UserInput;

    public List<Command> UndoableCommands { get; } = new List<Command>();

    public void ResetCurrentCommand() => 
      CurrentCommand?.Reset();

    public void SetCurrentCommand(Command command) =>
      CurrentCommand = command;
    
    public void AddCommand(Command command)
    {
      if(command.IsUndoable)
        UndoableCommands.Add(command);
    }

    public void RemoveCommand()
    {
      
    }
  }
}