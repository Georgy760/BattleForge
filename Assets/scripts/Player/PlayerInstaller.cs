using Cinemachine;
using healthsystem;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

public class PlayerInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private PlayerController Player;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private VariableJoystick Joystick;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private HealthBar HealthBar;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PlayerInstaller>().FromInstance(this);
        Container.Bind(typeof(HealthBar)).FromInstance()
        if(Player.GetComponent<PlayerController>())
        {
            Player.GetComponent<PlayerController>().joystick = Joystick;
        }
        
        PlayerController playerInstance = Container.InstantiatePrefabForComponent<PlayerController>(Player, playerSpawnPoint.position, Quaternion.identity, null);
        Container.Bind<PlayerUnit>().FromInstance(playerInstance).AsSingle().NonLazy();
        cinemachineVirtualCamera.Follow = playerInstance.transform;
        
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
}