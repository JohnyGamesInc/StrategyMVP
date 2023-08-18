using _Strategy._Main.Abstractions;
using UniRx;
using UnityEngine;


namespace _Strategy._Main.Core
{
    
    public sealed class AutoAttackAgent : MonoBehaviour
    {

        [SerializeField] private ChomperCommandsQueue _chomperCommandsQueue;

        
        private void Start()
        {
            AutoAttackEvaluator.AutoAttackCommands
                .ObserveOnMainThread()
                .Where(command => command.Attacker == gameObject)
                .Where(command => command.Attacker != null && command.Target != null)
                .Subscribe(command => AutoAttack(command.Target))
                .AddTo(this);
        }


        private void AutoAttack(GameObject target)
        {
            _chomperCommandsQueue.Clear();
            _chomperCommandsQueue.EnqueueCommand(new AutoAttackUnitCommand(target.GetComponent<IAttackable>()));
        }
        

    }
}