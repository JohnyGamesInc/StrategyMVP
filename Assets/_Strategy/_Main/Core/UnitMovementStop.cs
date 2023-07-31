using System;
using _Strategy._Main.Utils.AsyncExtensions;
using UnityEngine;
using UnityEngine.AI;


namespace _Strategy._Main.Core
{
    
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        
        [SerializeField] private NavMeshAgent _agent;
        
        public event Action OnStop;


        private void OnValidate() => _agent ??= GetComponent<NavMeshAgent>();
        
        
        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0.0f)
                    {
                        OnStop?.Invoke();
                    }
                }
            }
        }
        
        
        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
        
        
        
        private sealed class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
        {
            
            private readonly UnitMovementStop _unitMovementStop;


            public StopAwaiter(UnitMovementStop unitMovementStop)
            {
                _unitMovementStop = unitMovementStop;
                _unitMovementStop.OnStop += OnStop;
            }
            
            
            private void OnStop()
            {
                _unitMovementStop.OnStop -= OnStop;
                OnWaitFinish(new AsyncExtensions.Void());
            }
        }
        
        
    }
}