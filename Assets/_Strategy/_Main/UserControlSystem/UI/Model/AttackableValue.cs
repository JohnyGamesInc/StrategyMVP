using System;
using _Strategy._Main.Abstractions;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Configs/" + nameof(AttackableValue))]
    public sealed class AttackableValue : ScriptableObject
    {
        
        public IAttackable CurrentValue { get; private set; }
        
        public event Action<IAttackable> OnNewValueSubscription = delegate(IAttackable attackable) {  };


        public void SetValue(IAttackable value)
        {
            CurrentValue = value;
            OnNewValueSubscription(value);
        }
        
        
    }
}