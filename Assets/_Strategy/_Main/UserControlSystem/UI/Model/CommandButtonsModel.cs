﻿using System;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.UI.Model.CommandCreators;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    public sealed class CommandButtonsModel
    {
        
        public event Action<ICommandExecutor> OnCommandAccepted = delegate(ICommandExecutor executor) {  };
        public event Action OnCommandSent = () => { };
        public event Action OnCommandCancel = () => { };

        [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
        [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
        [Inject] private CommandCreatorBase<IStopCommand> _stopper;
        [Inject] private CommandCreatorBase<IMoveCommand> _mover;
        [Inject] private CommandCreatorBase<IPatrolCommand> _patroller;

        private bool _commandIsPending;

        
        public void OnCommandButtonClicked(ICommandExecutor commandExecutor)
        {
            if (_commandIsPending)
                ProcessOnCancel();

            _commandIsPending = true;
            OnCommandAccepted(commandExecutor);

            _unitProducer.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            
            _attacker.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            
            _stopper.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            
            _mover.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));

            _patroller.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
        }

        public void ExecuteCommandWrapper(ICommandExecutor commandExecutor, object command)
        {
            commandExecutor.ExecuteCommand(command);
            _commandIsPending = false;
            OnCommandSent();
        }


        public void OnSelectionChanged()
        {
            _commandIsPending = false;
            ProcessOnCancel();
        }


        private void ProcessOnCancel()
        {
            _unitProducer.ProcessCancel(); 
            _attacker.ProcessCancel();
            _stopper.ProcessCancel(); 
            _mover.ProcessCancel(); 
            _patroller.ProcessCancel(); 
            
            OnCommandCancel();
        }

        
    }
}