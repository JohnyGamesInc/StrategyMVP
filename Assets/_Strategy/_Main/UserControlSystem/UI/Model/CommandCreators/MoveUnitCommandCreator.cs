using System;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using _Strategy._Main.Utils.AssetsInjector;
using UnityEngine;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class MoveUnitCommandCreator : CommandCreatorBase<IMoveCommand>
    {

        [Inject] private AssetsContext _context; //TODO probably also useless here

        private Action<IMoveCommand> _creationCallback;

        
        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnNewValueSubscription += OnNewValue;
        }


        private void OnNewValue(Vector3 groundClick)
        {
            // TODO in example inject was used - probably extra 
            // _creationCallback?.Invoke(_context.Inject(new MoveUnitCommand(groundClick)));
            _creationCallback?.Invoke(new MoveUnitCommand(groundClick));
            _creationCallback = null;
        }
        
        
        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }


        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
        
        
    }
}