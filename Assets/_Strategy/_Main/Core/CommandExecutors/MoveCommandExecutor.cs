using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} Moves");
        }
        
        
    }
}