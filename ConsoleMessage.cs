namespace Test
{
  public class ConsoleMessage
  {
    private const string DefaultText = "Введите команду";
    public string Text { get; set; } = DefaultText;

    public void SetDefault() => 
      Text = DefaultText;

    public void AddDefault() =>
      Text += "\n" + DefaultText;
  }
}