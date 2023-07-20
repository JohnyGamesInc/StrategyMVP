using System;
using _Strategy._Main.Abstractions;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Configs/" + nameof(SelectableValue))]
    public sealed class SelectableValue : ScriptableObject
    {
        
        public ISelectable CurrentValue { get; private set; }
        
        public event Action<ISelectable> OnSelectedSubscription = delegate(ISelectable selectable) {  };


        public void SetValue(ISelectable value)
        {
            if (CurrentValue != null)
                CurrentValue.Outline.enabled = false;
            
            CurrentValue = value;
            
            if (CurrentValue != null)
                CurrentValue.Outline.enabled = true;

            OnSelectedSubscription(value);
        }

    }
}