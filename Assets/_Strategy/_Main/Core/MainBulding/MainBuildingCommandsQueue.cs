using _Strategy._Main.Abstractions.Commands;
using UnityEngine;
using Zenject;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class MainBuildingCommandsQueue : MonoBehaviour, ICommandsQueue
    {

        [Inject]
        private CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;

        
        
        public void Clear()
        {
        }


        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
        }
        
        

    }
}