using System;
using System.Collections.Generic;
using Test.Banks;

namespace Test.Commands
{
  public class TransferCommand : Command
  {
    private Account _from;
    private Account _to;
    
    public TransferCommand(Bank bank, CurrentState currentState, ConsoleMessage message) : base(bank, currentState, message)
    {
      Actions = new List<Func<bool>> {TryShowOpenAccounts, TryFindAccountFrom, TryFindAccountTo, TrySend};
    }

    public override bool IsUndoable { get; } = true;

    public override void Undo() => 
      Bank.RefundLastTransfer();

    private bool TryShowOpenAccounts()
    {
      if (Bank.OpenAccountsId().Length < 2)
      {
        Message.Text = "Открыто меньше 2 счетов. Создайте новые.";
        Reset();
        return false;
      }

      Message.Text = "Cчета\n" + 
                     Bank.OpenAccountsId().AsString() + 
                     "\nВведите номер счета, с которого хотите отправить";
      return true;
    }

    private bool TryFindAccountFrom() => 
      TryFindAccount("Введите номер счета, на который хотите получить", ref _from);

    private bool TryFindAccountTo() => 
      TryFindAccount("Введите сумму, которую хотите отправить", ref _to);

    private bool TryFindAccount(string trueMessage, ref Account refAccount)
    {
      if (Bank.TryFindAccountById(CurrentState.UserInput, out Account account))
      {
        refAccount = account;
        Message.Text = trueMessage;
        return true;
      }

      Message.Text = "Счет не найден. Попробуйте ввести другой.";
      return false;
    }

    private bool TrySend()
    {
      Bank.Transfer(_from, _to, float.Parse(CurrentState.UserInput));
      Message.Text = "Отправлено.";
      return true;
    }
  }
}