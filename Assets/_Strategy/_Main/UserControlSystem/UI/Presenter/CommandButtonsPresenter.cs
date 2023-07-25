using System;
using System.Collections.Generic;
using _Strategy._Main.Abstractions;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using _Strategy._Main.UserControlSystem.UI.Model;
using _Strategy._Main.UserControlSystem.UI.View;
using _Strategy._Main.Utils.AssetsInjector;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Presenter
{
    
    public class CommandButtonsPresenter : MonoBehaviour
    {

        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _commandButtonsView;
        [SerializeField] private AssetsContext _assetsContext;

        private ISelectable _currentSelectable;


        
        private void Start()
        {
            _selectable.OnSelectedSubscription += OnSelectedSubscribe;
            OnSelectedSubscribe(_selectable.CurrentValue);
            _commandButtonsView.OnClickSubscription += OnButtonClickSubscribe;
        }
        
        

        private void OnSelectedSubscribe(ISelectable selectable)
        {
            if (_currentSelectable != selectable)
            {
                _currentSelectable = selectable;
                _commandButtonsView.Clear();

                if (selectable != null)
                {
                    var commandExecutors = new List<ICommandExecutor>();
                    commandExecutors.AddRange
                    (
                        (selectable as Component).GetComponentsInParent<ICommandExecutor>()
                    );
                    _commandButtonsView.MakeLayout(commandExecutors);
                }
            }
        }


        private void OnButtonClickSubscribe(ICommandExecutor commandExecutor)
        {
            var isExecuted = false;
            
            if (commandExecutor is CommandExecutorBase<IProduceUnitCommand> produceUnit)
            {
                produceUnit.ExecuteCommand(_assetsContext.Inject(new ProduceUnitCommand()));
                isExecuted = true;
            }
            
            if (commandExecutor is CommandExecutorBase<IAttackCommand> attackUnit)
            {
                attackUnit.ExecuteCommand(new AttackUnitCommand());
                isExecuted = true;
            }
            
            if (commandExecutor is CommandExecutorBase<IMoveCommand> moveUnit)
            {
                moveUnit.ExecuteCommand(new MoveUnitCommand());
                isExecuted = true;
            }
            
            if (commandExecutor is CommandExecutorBase<IPatrolCommand> patrolUnit)
            {
                patrolUnit.ExecuteCommand(new PatrolUnitCommand());
                isExecuted = true;
            }
            
            if (commandExecutor is CommandExecutorBase<IStopCommand> stopUnit)
            {
                stopUnit.ExecuteCommand(new StopUnitCommand());
                isExecuted = true;
            }


            if (!isExecuted) 
                throw new ApplicationException(
                    $"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClickSubscribe)}:" +
                    $"Unknown type of Commands Executor: [{commandExecutor.GetType().FullName}] !");
        }


    }
}