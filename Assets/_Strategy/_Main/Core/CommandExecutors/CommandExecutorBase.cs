﻿using System.Threading.Tasks;
using UnityEngine;


namespace _Strategy._Main.Abstractions.Commands
{
    
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor<T> where T : class, ICommand
    {

        public async Task TryExecuteCommand(object command)
        {
            var specificCommand = command as T;
            if (specificCommand != null)
            {
                await ExecuteSpecificCommand(specificCommand);
            }
        }

        
        protected abstract Task ExecuteSpecificCommand(T command);

        
    }
}