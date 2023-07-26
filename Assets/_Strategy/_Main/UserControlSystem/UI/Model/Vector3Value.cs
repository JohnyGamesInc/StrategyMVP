using System;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Model
{

    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Configs/" + nameof(Vector3Value))]
    public sealed class Vector3Value : ScriptableObject
    {

        public Vector3 CurrentValue { get; private set; }

        public event Action<Vector3> OnNewValueSubscription = delegate(Vector3 vector3) {  };

        
        public void SetValue(Vector3 newVector)
        {
            CurrentValue = newVector;
            OnNewValueSubscription(newVector);
        }

        
    }
}