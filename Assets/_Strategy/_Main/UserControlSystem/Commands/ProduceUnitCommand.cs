using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.Utils.AssetsInjector;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.Commands
{
    
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        
        [InjectAsset("ChomperUnit")] private GameObject _unitPrefab;

        public GameObject UnitPrefab => _unitPrefab;


        public ProduceUnitCommand()
        {
        }

        public ProduceUnitCommand(GameObject unitPrefab)
        {
            _unitPrefab = unitPrefab;
        }

        
    }
}