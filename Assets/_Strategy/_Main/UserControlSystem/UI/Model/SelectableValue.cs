using System;
using _Strategy._Main.Abstractions;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Configs/" + nameof(SelectableValue))]
    public sealed class SelectableValue : ScriptableObject
    {
        
        public ISelectable CurrentValue { get; private set; }
        
        public event Action<ISelectable> OnNewValueSubscription = delegate(ISelectable selectable) {  };


        public void SetValue(ISelectable value)
        {
            SetOutline(false);
            CurrentValue = value;
            SetOutline(true);

            OnNewValueSubscription(value);
        }

        
        private void SetOutline(bool enable)
        {
            if (CurrentValue != null)
                if (CurrentValue.Outline != null)
                    CurrentValue.Outline.enabled = enable;
        }

        
    }
}