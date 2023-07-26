using UnityEngine;
using QuickOutline;


namespace _Strategy._Main.Abstractions
{
    
    public interface ISelectable : IHealthHolder
    {
        
        Sprite Icon { get; }

        Outline Outline { get; }

        Transform PivotPoint { get; }

    }
}