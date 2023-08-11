using System;
using _Strategy._Main.Abstractions;
using _Strategy._Main.Core.CommandExecutors;
using QuickOutline;
using UnityEngine;


namespace _Strategy._Main.Core
{
    
    internal sealed class UnitBase : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer
    {
        
        [SerializeField] private Outline _outline;
        [SerializeField] private StopCommandExecutor _stopCommand;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _unitsParent;
        
        [SerializeField] private Sprite _icon;

        [SerializeField] private float _maxHealth = 100.0f;
        [SerializeField] private float _damage = 25.0f;
        

        private int _playDeadTriggerHash;
        
        private float _health = 100.0f;

        public float Health => _health;
        
        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        public Outline Outline => _outline;

        public Transform PivotPoint => _transform;
        
        public float Damage => _damage;


        
        private void Awake()
        {
            _playDeadTriggerHash = Animator.StringToHash(AnimationTypes.PlayDead.ToString());
        }


        public void ReceiveDamage(float amount)
        {
            if (_health >= 0)
            {
                _health -= amount;
            }
            
            if (_health <= 0)
            {
                Destroy();
            }
        }


        private async void Destroy()
        {
            _animator.SetTrigger(_playDeadTriggerHash);
            await _stopCommand.TryExecuteCommand(new StopUnitCommand());
            Destroy(gameObject, 1.0f);
        }
        
        
    }
}
