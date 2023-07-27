using System;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using UnityEngine;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class MoveUnitCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        
        private Action<IMoveCommand> _creationCallback;

        
        [Inject]
        private void Init(Vector3Value groundClicks) => groundClicks.OnNewValueChanged += OnNewValue;
        
        
        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(new MoveUnitCommand(groundClick));
            _creationCallback = null;
        }
        
        
        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback) => 
            _creationCallback = creationCallback;


        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
        
        
    }
}