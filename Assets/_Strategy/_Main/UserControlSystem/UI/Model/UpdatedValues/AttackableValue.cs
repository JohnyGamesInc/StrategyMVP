using _Strategy._Main.Abstractions;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Configs/" + nameof(AttackableValue))]
    public sealed class AttackableValue : ScriptableObjectValueBase<IAttackable>
    {
        
        
    }
}