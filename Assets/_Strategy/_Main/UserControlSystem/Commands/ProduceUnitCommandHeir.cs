using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.Utils.AssetsInjector;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.Commands
{
    
    public sealed class ProduceUnitCommandHeir : ProduceUnitCommand
    {
        
        [InjectAsset("ChomperUnit")] private GameObject _unitPrefab;

        public GameObject UnitPrefab => _unitPrefab;


        public ProduceUnitCommandHeir()
        {
        }

        public ProduceUnitCommandHeir(GameObject unitPrefab)
        {
            _unitPrefab = unitPrefab;
        }

        
    }
}