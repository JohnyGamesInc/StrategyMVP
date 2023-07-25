using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        
        protected override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} Patrols");
        }
        
        
    }
}