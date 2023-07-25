using UnityEngine;


namespace _Strategy._Main.Abstractions.Commands
{
    
    public interface IProduceUnitCommand : ICommand
    {

        GameObject UnitPrefab { get; }
        
    }
}