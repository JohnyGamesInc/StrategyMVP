using _Strategy._Main.Abstractions;
using Zenject;


namespace _Strategy._Main.Core
{
    
    public class ChomperInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().FromComponentInChildren();
            Container.Bind<float>().WithId("AttackDistance").FromInstance(5.0f);
            Container.Bind<int>().WithId("AttackPeriod").FromInstance(1400);
        }
        
    }
}