using _Strategy._Main.UserControlSystem.UI.Model;
using _Strategy._Main.Utils.AssetsInjector;
using UnityEngine;
using Zenject;


namespace _Strategy._Main
{
    
    [CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
    public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
    {
        
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private SelectableValue _selectables;
        [SerializeField] private AttackableValue _attackableClicksRMB;


        public override void InstallBindings()
        {
            Container.BindInstances(_legacyContext, _groundClicksRMB, _attackableClicksRMB, _selectables);
        }
        
        
    }
}