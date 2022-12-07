using Zenject;

namespace Common.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public ControllerManager ControllerManagerPrefab;
        public override void InstallBindings()
        {
            BindControllerService();
        }

        private void BindControllerService()
        {
            Container
                .Bind<IControllerService>()
                .FromComponentInNewPrefab(ControllerManagerPrefab)
                .UnderTransform(transform).AsSingle();
        }
    }
}