using UnityEngine;


namespace _Strategy._Main.Abstractions
{
    
    public interface ISelectable
    {

        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }

    }
}