﻿using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        
        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log($"{name} Stops");
        }
        
        
    }
}