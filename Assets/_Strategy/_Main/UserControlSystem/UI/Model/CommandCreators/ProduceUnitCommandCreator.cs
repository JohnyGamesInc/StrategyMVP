using System;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using _Strategy._Main.Utils.AssetsInjector;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class ProduceUnitCommandCreator : CommandCreatorBase<IProduceUnitCommand>
    {

        [Inject] private AssetsContext _context;
        
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new ProduceUnitCommand()));
        }
        
        
    }
}