using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
    {
        
        [ContextMenu("ProduceUnit")]
        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(
                    command.UnitPrefab, 
                    new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)), 
                    Quaternion.identity,
                    GetComponent<MainBuilding>().UnitsParent
                )
                .name = command.UnitPrefab.name;
        }
        
    }
}