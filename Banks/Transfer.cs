namespace Test.Banks
{
  public class Transfer
  {
    private readonly Account _from;
    private readonly Account _to;
    private readonly float _amount;

    public Transfer(Account from, Account to, float amount)
    {
      _from = from;
      _to = to;
      _amount = amount;
    }

    public void Send()
    {
      _from.ChangeAmount(-1 * _amount);
      _to.ChangeAmount(_amount);
    }

    public void Refund()
    {
      _from.ChangeAmount(_amount);
      _to.ChangeAmount(-1 * _amount);
    }
  }
}