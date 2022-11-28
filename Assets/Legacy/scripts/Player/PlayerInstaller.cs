using UnityEngine;
using Zenject;

namespace Legacy.scripts.Player
{
    public class PlayerInstaller : MonoInstaller//, IInitializable
    {
        [SerializeField] private PlayerController Player;
        [SerializeField] private Transform StartPoint;
        [SerializeField] private VariableJoystick Joystick;
        //[SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerInstaller>().FromInstance(this);
            //Container.Bind(typeof(HealthBar)).FromInstance();
            if(Player.GetComponent<PlayerController>())
            {
                Player.GetComponent<PlayerController>().joystick = Joystick;
            }
        
            PlayerController playerInstance = Container.InstantiatePrefabForComponent<PlayerController>(Player, StartPoint.position, Quaternion.identity, null);
            Container.Bind<PlayerController>().FromInstance(playerInstance).AsSingle().NonLazy();
            //cinemachineVirtualCamera.Follow = playerInstance.transform;
        
        }

        /*public void Initialize()
    {
        throw new System.NotImplementedException();
    }*/
    }
}