using _Strategy._Main.Abstractions;
using UnityEngine;


namespace _Strategy._Main.Core
{
    
    public class FractionMember : MonoBehaviour, IFractionMember
    {

        [field: SerializeField] public int FractionId { get; private set; }
        

        public void SetFraction(int fractionId)
        {
            FractionId = fractionId;
        }


    }
}