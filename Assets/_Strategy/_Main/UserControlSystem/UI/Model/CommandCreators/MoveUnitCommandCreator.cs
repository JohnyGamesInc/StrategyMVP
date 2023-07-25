using System;
using _Strategy._Main.Abstractions.Commands;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class MoveUnitCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        
        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
        
        
    }
}