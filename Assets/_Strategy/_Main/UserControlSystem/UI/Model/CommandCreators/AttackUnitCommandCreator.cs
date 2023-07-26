using System;
using _Strategy._Main.Abstractions;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using _Strategy._Main.Utils.AssetsInjector;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class AttackUnitCommandCreator : CommandCreatorBase<IAttackCommand>
    {

        [Inject] private AssetsContext _context;

        private event Action<IAttackCommand> _creationCallback;


        [Inject]
        private void Init(AttackableValue groundClicks)
        {
            groundClicks.OnNewValueSubscription += OnNewValue;
        }

        
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }


        private void OnNewValue(IAttackable attackable)
        {
            _creationCallback?.Invoke(new AttackUnitCommand(attackable));
            _creationCallback = null;
        }


        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }


    }
}