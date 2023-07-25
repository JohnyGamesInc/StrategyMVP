﻿using _Strategy._Main.Abstractions.Commands;
using _Strategy._Main.UserControlSystem.UI.Model.CommandCreators;
using _Strategy._Main.Utils.AssetsInjector;
using UnityEngine;
using Zenject;


namespace _Strategy._Main.UserControlSystem.UI.Model
{
    
    internal sealed class UIModelInstaller : MonoInstaller
    {

        [SerializeField] private AssetsContext _legacyContext;

        
        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_legacyContext);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopUnitCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();
        }

        
    }
}