using System;
using System.Collections.Generic;
using Test.Banks;

namespace Test.Commands
{
  public abstract class Command
  {
    public abstract bool IsUndoable { get; }

    protected readonly Bank Bank;
    protected readonly CurrentState CurrentState;
    protected readonly ConsoleMessage Message;

    protected List<Func<bool>> Actions { get; set; }
    private int _actionId;

    protected Command(Bank bank, CurrentState currentState, ConsoleMessage message)
    {
      Bank = bank;
      CurrentState = currentState;
      Message = message;
    }

    public virtual void Execute()
    {
      CurrentState.SetCurrentCommand(this);
     
      if (Actions[_actionId] == null)
        return;
      
      if (Actions[_actionId].Invoke())
        _actionId++;
      
      if(Actions.Count == _actionId)
        Complete();
    }

    public abstract void Undo();

    public void Reset()
    {
      _actionId = 0;
      Message.AddDefault();
      CurrentState.SetCurrentCommand(null);
    }

    private void Complete()
    {
      if(IsUndoable) 
        CurrentState.AddCommand(this);
      
      Reset();
    }
  }
}