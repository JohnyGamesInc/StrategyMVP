using System;
using _Strategy._Main.Abstractions.Commands;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class StopUnitCommandCreator : CommandCreatorBase<IStopCommand>
    {
        
        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
        
        
    }
}