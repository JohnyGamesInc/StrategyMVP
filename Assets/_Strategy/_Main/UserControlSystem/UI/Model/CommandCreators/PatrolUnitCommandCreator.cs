using System;
using _Strategy._Main.Abstractions.Commands;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class PatrolUnitCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        
        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
        
        
    }
}