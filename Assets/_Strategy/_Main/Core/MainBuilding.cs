using _Strategy._Main.Abstractions;
using _Strategy._Main.Abstractions.Commands;
using QuickOutline;
using UnityEngine;
using UnityEngine.UIElements;


namespace _Strategy._Main.Core
{
    
    internal sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {

        [SerializeField] private Outline _outline;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000.0f;
        [SerializeField] private Sprite _icon;

        private float _health = 1000.0f;

        public float Health => _health;
        
        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        public Outline Outline => _outline; 

        
        [ContextMenu("ProduceUnit")]
        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(
                    command.UnitPrefab, 
                    new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)), 
                    Quaternion.identity,
                    _unitsParent
                )
                .name = command.UnitPrefab.name;
        }
        
        
    }
}
