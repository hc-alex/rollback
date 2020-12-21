using System.Collections.Generic;
using System.Linq;

namespace Test.Banks
{
  public class Bank
  {
    private readonly List<Account> _openAccounts  = new List<Account>();
    private readonly List<Account> _closedAccounts  = new List<Account>();

    private readonly List<Transfer> _transfers = new List<Transfer>();
    
    public string[] OpenAccountsId() =>
      _openAccounts?.Select(a => a.Id).ToArray();

    public string[] GetOpenAccounts() =>
      _openAccounts?.Select(a => a.Id + " " + a.Amount).ToArray();

    public void OpenAccount() => 
      _openAccounts.Add(new Account());

    public bool TryCloseAccountById(string id)
    {
      Account account = _openAccounts.Find(a => a.Id == id);

      if (account == null)
        return false;
      
      _openAccounts.Remove(account);
      _closedAccounts.Add(account);

      return true;
    }

    public bool TryFindAccountById(string id, out Account account)
    {
      account = _openAccounts.First(a => a.Id == id);
      return account != null;
    }

    public void Transfer(Account from, Account to, float amount)
    {
      Transfer transfer = new Transfer(from, to, amount);
      transfer.Send();
      _transfers.Add(transfer);
    }

    public void CloseLastOpenAccount() => 
      MoveLastAccount(_openAccounts, _closedAccounts);

    public void OpenLastClosedAccount() => 
      MoveLastAccount(_closedAccounts, _openAccounts);

    public void RefundLastTransfer()
    {
      Transfer transfer = _transfers.Last();
      transfer.Refund();
      _transfers.Remove(transfer);
    }

    private void MoveLastAccount(List<Account> from, List<Account> to)
    {
      Account account = from.Last();
      to.Insert(0, account);
      from.Remove(account);
    }
  }
}