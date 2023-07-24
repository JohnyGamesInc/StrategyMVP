using _Strategy._Main.Abstractions.Commands;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.Commands
{
    
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        
        [SerializeField] private GameObject _unitPrefab;

        public GameObject UnitPrefab => _unitPrefab;


    }
}