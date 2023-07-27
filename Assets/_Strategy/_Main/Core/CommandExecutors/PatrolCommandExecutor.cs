using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        
        protected override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} Patrols from [{command.From}] to [{command.To}]");
        }
        
        
    }
}