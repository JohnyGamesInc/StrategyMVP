using System.Threading.Tasks;
using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        
        protected override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} Attacks {command.Target} with HP [{command.Target.Health}/{command.Target.MaxHealth}]");
        }
        
        
    }
}