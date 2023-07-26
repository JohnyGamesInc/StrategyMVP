using System;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    public abstract class ScriptableObjectValueBase<T> : ScriptableObject
    {

        public T CurrentValue { get; private set; }
        
        public event Action<T> OnNewValueChanged = delegate(T obj) {  };

        
        public virtual void SetValue(T value)
        {
            CurrentValue = value;
            OnNewValueChanged(value);
        }

        
    }
}