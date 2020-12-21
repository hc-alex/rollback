using System;
using System.Collections.Generic;
using System.Linq;
using Test.Banks;

namespace Test.Commands
{
  public class UndoCommand : Command
  {
    public UndoCommand(Bank bank, CurrentState currentState, ConsoleMessage message) : base(bank, currentState, message)
    {
      Actions = new List<Func<bool>> {UndoAnotherCommand};
    }

    public override bool IsUndoable { get; } = false;

    public override void Undo()
    {
    }

    private bool UndoAnotherCommand()
    {
      if (CurrentState.UndoableCommands.Any())
      {
        CurrentState.UndoableCommands.Last().Undo();
        CurrentState.UndoableCommands.RemoveAt(CurrentState.UndoableCommands.Count - 1);
      }

      Message.Text = "Предыдущая операция отменена.";
      
      return true;
    }
  }
}