using _Strategy._Main.Abstractions.Commands;
using UnityEngine;
using UnityEngine.AI;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving to {command.Target}");
            GetComponent<NavMeshAgent>().destination = command.Target;
        }
        
        
    }
}