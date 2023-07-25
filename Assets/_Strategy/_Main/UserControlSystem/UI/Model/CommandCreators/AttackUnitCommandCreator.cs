using System;
using _Strategy._Main.Abstractions.Commands;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class AttackUnitCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
        
        
    }
}