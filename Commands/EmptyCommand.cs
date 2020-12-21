using Test.Banks;

namespace Test.Commands
{
  class EmptyCommand : Command
  {
    public EmptyCommand(Bank bank, CurrentState currentState, ConsoleMessage message) : base(bank, currentState, message)
    {
    }

    public override bool IsUndoable { get; } = false;

    public override void Execute()
    {
      Message.Text = "Команда не существует.";  
      Message.AddDefault();
    }


    public override void Undo()
    {
    }
  }
}