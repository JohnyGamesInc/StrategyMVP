using _Strategy._Main.Abstractions;
using QuickOutline;
using UnityEngine;


namespace _Strategy._Main.Core
{
    
    internal sealed class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {

        [SerializeField] private Outline _outline;
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000.0f;
        [SerializeField] private Sprite _icon;

        private float _health = 1000.0f;

        public float Health => _health;
        
        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        public Outline Outline => _outline; 


        
        [ContextMenu("ProduceUnit")]
        public void ProduceUnit()
        {
            Instantiate(
                    _unitPrefab, 
                    new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)), 
                    Quaternion.identity,
                    _unitsParent
                    )
                .name = _unitPrefab.name;
        }

    }
}
