using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        
        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} Attacks");
        }
        
        
    }
}