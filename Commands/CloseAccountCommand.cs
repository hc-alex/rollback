using System;
using System.Collections.Generic;
using Test.Banks;

namespace Test.Commands
{
  public class CloseAccountCommand : Command
  {
    public CloseAccountCommand(Bank bank, CurrentState currentState, ConsoleMessage message) : base(bank, currentState, message)
    {
      Actions = new List<Func<bool>> {TryShowOpenAccounts, TryCloseAccount};
    }

    public override bool IsUndoable { get; } = true;

    public override void Undo() => 
      Bank.OpenLastClosedAccount();

    private bool TryShowOpenAccounts()
    {
      if (Bank.OpenAccountsId().Length == 0)
      {
        Message.Text = "Открытых счетов нет.";
        Reset();
        return false;
      }

      Message.Text = "Cчета\n" 
                     + Bank.OpenAccountsId().AsString()
                     + "\nВведите номер счета, который хотите закрыть";
      return true;
    }

    private bool TryCloseAccount()
    {
      if (Bank.TryCloseAccountById(CurrentState.UserInput))
      {
        Message.Text = "Счет закрыт.";
        return true;
      }
      
      Message.Text = "Счет не найден. Попробуйте ввести другой.";
      return false;
    }
  }
}