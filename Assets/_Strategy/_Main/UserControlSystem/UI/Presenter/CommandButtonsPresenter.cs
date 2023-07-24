﻿using System;
using System.Collections.Generic;
using _Strategy._Main.Abstractions;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using _Strategy._Main.UserControlSystem.UI.Model;
using _Strategy._Main.UserControlSystem.UI.View;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Presenter
{
    
    public class CommandButtonsPresenter : MonoBehaviour
    {

        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _commandButtonsView;

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
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
                unitProducer.ExecuteCommand(new ProduceUnitCommand());
            else
                throw new ApplicationException(
                    $"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClickSubscribe)}:" +
                    $"Unknown type of Commands Executor: [{commandExecutor.GetType().FullName}] !");
        }


    }
}