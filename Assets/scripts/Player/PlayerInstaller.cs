using Cinemachine;
using healthsystem;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerUnit PlayerUnit;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private VariableJoystick Joystick;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private HealthBar HealthBar;
    public override void InstallBindings()
    {
        if(PlayerUnit.GetComponent<PlayerController>())
        {
            PlayerUnit.GetComponent<PlayerController>().joystick = Joystick;
        }
        
        var playerInstance = Container.InstantiatePrefabForComponent<PlayerUnit>(PlayerUnit, playerSpawnPoint.position, Quaternion.identity, null);
        Container.Bind<PlayerUnit>().FromInstance(playerInstance).AsSingle().NonLazy();
        HealthBar.GetComponent<LookAtCam>().cam = cinemachineVirtualCamera.transform;
        //Container.Bind<IDamageable>().To<HealthBar>().AsSingle();
        var healthBarInstance = Container.InstantiatePrefabForComponent<HealthBar>(HealthBar, playerInstance.transform);
        Container.Bind<HealthBar>().FromInstance(healthBarInstance).AsSingle().NonLazy();
        
        //Container.Bind<IDamageable>().To<HealthData>().AsSingle();
        //Container.Bind<IDamageable>().To<Damageable>().FromInstance(new Damageable());
        cinemachineVirtualCamera.Follow = playerInstance.transform;
        
    }
}