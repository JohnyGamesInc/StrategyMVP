using System;
using System.Collections.Generic;
using System.Linq;
using _Strategy._Main.Abstractions.Commands;
using UnityEngine;
using UnityEngine.UI;


namespace _Strategy._Main.UserControlSystem.UI.View
{
    public sealed class CommandButtonsView : MonoBehaviour
    {

        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;
        [SerializeField] private GameObject _produceUnitButton;

        
        public event Action<ICommandExecutor> OnClickSubscription = delegate(ICommandExecutor executor) { };

        
        private Dictionary<Type, GameObject> _buttonsByExecutorType;


        private void Awake()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>
            {
                [typeof(CommandExecutorBase<IAttackCommand>)] = _attackButton,
                [typeof(CommandExecutorBase<IMoveCommand>)] = _moveButton,
                [typeof(CommandExecutorBase<IPatrolCommand>)] = _patrolButton,
                [typeof(CommandExecutorBase<IStopCommand>)] = _stopButton,
                [typeof(CommandExecutorBase<IProduceUnitCommand>)] = _produceUnitButton
            };
        }


        private void OnDestroy()
        {
            Clear();
        }


        public void MakeLayout(List<ICommandExecutor> commandExecutors)
        {
            for (int i = 0; i < commandExecutors.Count; i++)
            {
                var buttonGameObject = _buttonsByExecutorType
                    .First(type => type
                        .Key
                        .IsInstanceOfType(commandExecutors[i]))
                    .Value;
                
                buttonGameObject.SetActive(true);
                
                var button = buttonGameObject.GetComponent<Button>();
                var effectiveCounter = i;
                button.onClick.AddListener(() => OnClickSubscription(commandExecutors[effectiveCounter]));
            }
        }


        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }

        
    }
}