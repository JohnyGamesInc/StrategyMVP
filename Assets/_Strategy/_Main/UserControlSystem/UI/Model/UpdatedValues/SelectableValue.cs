using System;
using _Strategy._Main.Abstractions;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Configs/" + nameof(SelectableValue))]
    public sealed class SelectableValue : ScriptableObjectValueBase<ISelectable>
    {
        
        public override void SetValue(ISelectable value)
        {
            SetOutline(false);
            base.SetValue(value);
            SetOutline(true);
        }

        
        private void SetOutline(bool enable)
        {
            if (CurrentValue != null)
                if (CurrentValue.Outline != null)
                    CurrentValue.Outline.enabled = enable;
        }

        
    }
}