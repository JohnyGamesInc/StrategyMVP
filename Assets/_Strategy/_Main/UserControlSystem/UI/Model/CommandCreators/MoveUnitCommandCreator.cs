using System;
using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.Commands;
using UnityEngine;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model.CommandCreators
{
    
    public sealed class MoveUnitCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        
        // private Action<IMoveCommand> _creationCallback;
        //
        //
        // [Inject]
        // private void Init(Vector3Value groundClicks) => groundClicks.OnNewValueChanged += OnNewValue;
        //
        //
        // private void OnNewValue(Vector3 groundClick)
        // {
        //     _creationCallback?.Invoke(new MoveUnitCommand(groundClick));
        //     _creationCallback = null;
        // }


        protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveUnitCommand(argument);
        
    }
}