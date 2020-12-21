using System;
using System.Collections.Generic;
using Test.Banks;

namespace Test.Commands
{
  public class GetAccountsCommand : Command
  {
    public GetAccountsCommand(Bank bank, CurrentState currentState, ConsoleMessage message) : base(bank, currentState, message)
    {
      Actions = new List<Func<bool>> {TryGetOpenAccounts};
    }

    public override bool IsUndoable { get; } = false;

    public override void Undo()
    {
    }

    private bool TryGetOpenAccounts()
    {
      string[] accounts = Bank.GetOpenAccounts();
      Message.Text = accounts.Length == 0 ? "Открытых счетов нет." : "Cчета\n" + accounts.AsString();
      return true;
    }
  }
}