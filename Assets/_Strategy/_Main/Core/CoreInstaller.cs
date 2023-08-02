using Zenject;


namespace _Strategy._Main.Core
{
    
    public class CoreInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
        }
        
        
    }
}