namespace Test
{
  public static class Extensions
  {
    public static string AsString(this string[] strings) 
      => string.Join("\n", strings);
  }
}