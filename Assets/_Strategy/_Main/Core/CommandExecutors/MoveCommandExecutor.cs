using System;
using _Strategy._Main.Abstractions.Commands;
using UnityEngine;
using UnityEngine.AI;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _navAgent;
        
        [SerializeField] private UnitMovementStop _movementStop;
        
        private int _walkTrigger;
        private int _idleTrigger;
        
        
        private void Awake()
        {
            _walkTrigger = Animator.StringToHash("Walk");
            _idleTrigger = Animator.StringToHash("Idle");
        }


        protected override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            _navAgent.destination = command.Target;
            _animator.SetTrigger(_walkTrigger);
            await _movementStop;
            _animator.SetTrigger(_idleTrigger);
        }
        
        
    }
}