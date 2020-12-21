using System;
using System.Collections.Generic;
using Test.Banks;

namespace Test.Commands
{
  public class OpenAccountCommand : Command
  {
    public OpenAccountCommand(Bank bank, CurrentState currentState, ConsoleMessage message) : base(bank, currentState, message)
    {
      Actions = new List<Func<bool>> {TryOpenAccount};
    }

    public override bool IsUndoable { get; } = true;

    public override void Undo() => 
      Bank.CloseLastOpenAccount();

    private bool TryOpenAccount()
    {
      Bank.OpenAccount();
      Message.Text = "Счет открыт.";
      return true;
    }
  }
}