using System;
using _Strategy._Main.Abstractions;
using _Strategy._Main.Abstractions.Commands;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _Strategy._Main.Core.CommandExecutors
{
    
    public sealed class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maxUnitsInQueue = 6;


        private ReactiveCollection<IUnitProductionTask> _unitProductionQueue = new();
        
        public IReadOnlyReactiveCollection<IUnitProductionTask> UnitProductionQueue => _unitProductionQueue;

        
        private void Start()
        {
            Observable.EveryUpdate().Subscribe(_ => { Tick(); }).AddTo(this);
        }

        
        private void Tick()
        {
            if (_unitProductionQueue.Count != 0)
            {
                var innerTask = (UnitProductionTask) _unitProductionQueue[0];
                innerTask.TimeLeft -= Time.deltaTime;

                if (innerTask.TimeLeft <= 0)
                {
                    RemoveTaskAtIndex(0);
                    
                    Instantiate(
                            innerTask.UnitPrefab, 
                            new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)), 
                            Quaternion.identity,
                            _unitsParent
                        )
                        .name = innerTask.UnitPrefab.name;
                }
            }
        }


        [ContextMenu("ProduceUnit")]
        protected override void ExecuteSpecificCommand(IProduceUnitCommand command) =>
            _unitProductionQueue.Add(
                new UnitProductionTask(
                    command.UnitPrefab, 
                    command.Icon, 
                    command.UnitName,
                    command.ProductionTime));


        private void RemoveTaskAtIndex(int index)
        {
            for (int i = index; i < _unitProductionQueue.Count - 1; i++)
            {
                _unitProductionQueue[i] = _unitProductionQueue[i + 1];
            }
            
            _unitProductionQueue.RemoveAt(_unitProductionQueue.Count - 1);
        }
        
        
        public void Cancel(int index) => RemoveTaskAtIndex(index);


    }
}