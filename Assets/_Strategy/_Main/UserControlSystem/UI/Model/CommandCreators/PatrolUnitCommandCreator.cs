using System;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using _Strategy._Main.Utils.AssetsInjector;
using UnityEngine;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class PatrolUnitCommandCreator : CommandCreatorBase<IPatrolCommand>
    {

        [Inject] private AssetsContext _context;
        [Inject] private SelectableValue _selectable;
        
        private event Action<IPatrolCommand> _creationCallback;


        [Inject]
        private void Init(Vector3Value groundClicks) => groundClicks.OnNewValueSubscription += OnNewValue;


        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback) =>
            _creationCallback = creationCallback;


        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(new PatrolUnitCommand(_selectable.CurrentValue.PivotPoint.position, groundClick));
            _creationCallback = null;
        }

        
        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
        
        
    }
}