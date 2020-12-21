using System;

namespace Test.Banks
{
  public class Account
  {
    public Account()
    {
      Id = GenerateId();
      Amount = 100;
    }

    public string Id { get; }
    public float Amount { get; private set; }

    public void ChangeAmount(float value) => 
      Amount += value;

    private static string GenerateId() => 
      Guid.NewGuid().ToString("N");
  }
}