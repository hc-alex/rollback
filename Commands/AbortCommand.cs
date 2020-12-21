

using Test.Banks;

namespace Test.Commands
{
  public class AbortCommand : Command
  {
    public AbortCommand(Bank bank, CurrentState currentState, ConsoleMessage message) : base(bank, currentState, message)
    {
    }

    public override bool IsUndoable { get; } = false;

    public override void Undo()
    {
    }

    public override void Execute()
    {
      CurrentState?.ResetCurrentCommand();
      Message.SetDefault();
    }
  }
}