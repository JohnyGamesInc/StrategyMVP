using System.Threading;
using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {

        public CancellationTokenSource CancellationTokenSource { get; set; }

        
        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
        
        
    }
}