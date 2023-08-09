using _Strategy._Main.Abstractions;
using QuickOutline;
using UnityEngine;


namespace _Strategy._Main.Core
{
    
    internal sealed class MainBuilding : MonoBehaviour, ISelectable, IAttackable
    {

        [SerializeField] private Outline _outline;
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000.0f;
        [SerializeField] private Sprite _icon;

        private float _health = 1000.0f;

        
        public float Health => _health;
        
        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        public Outline Outline => _outline;
        
        public Transform UnitsParent => _unitsParent;
        
        public Transform PivotPoint => _transform;

        
    }
}
