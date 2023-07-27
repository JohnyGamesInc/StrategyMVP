using System.Collections.Generic;
using _Strategy._Main.Abstractions;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.UI.Model;
using _Strategy._Main.UserControlSystem.UI.View;
using UnityEngine;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Presenter
{
    
    internal sealed class CommandButtonsPresenter : MonoBehaviour
    {

        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _commandButtonsView;

        [Inject] private CommandButtonsModel _commandButtonsModel;

        private ISelectable _currentSelectable;


        
        private void Start()
        {
            _commandButtonsView.OnClickSubscription += _commandButtonsModel.OnCommandButtonClicked;
            _commandButtonsModel.OnCommandSent += _commandButtonsView.UnblockAllInteractions;
            _commandButtonsModel.OnCommandCancel += _commandButtonsView.UnblockAllInteractions;
            _commandButtonsModel.OnCommandAccepted += _commandButtonsView.BlockInteractions;
            
            _selectable.OnNewValueChanged += OnNewValueSubscribe;
            OnNewValueSubscribe(_selectable.CurrentValue);
        }


        private void OnDestroy()
        {
            _commandButtonsView.OnClickSubscription -= _commandButtonsModel.OnCommandButtonClicked;
            _commandButtonsModel.OnCommandSent -= _commandButtonsView.UnblockAllInteractions;
            _commandButtonsModel.OnCommandCancel -= _commandButtonsView.UnblockAllInteractions;
            _commandButtonsModel.OnCommandAccepted -= _commandButtonsView.BlockInteractions;
            _selectable.OnNewValueChanged -= OnNewValueSubscribe;
        }


        private void OnNewValueSubscribe(ISelectable selectable)
        {
            if (_currentSelectable != selectable)
            {
                // Under the big question
                // if (_currentSelectable != null) 
                _commandButtonsModel.OnSelectionChanged();
                
                _currentSelectable = selectable;
                _commandButtonsView.ClearButtonsPanel();

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

        
    }
}