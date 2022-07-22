using Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerUnit playerUnit;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private VariableJoystick Joystick;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    public override void InstallBindings()
    {
        if(playerUnit.GetComponent<PlayerController>())
        {
            playerUnit.GetComponent<PlayerController>().joystick = Joystick;
        }
        var playerInstance = Container.InstantiatePrefabForComponent<PlayerUnit>(playerUnit, playerSpawnPoint.position, Quaternion.identity, null);

        Container.Bind<PlayerUnit>().FromInstance(playerInstance).AsSingle().NonLazy();
        cinemachineVirtualCamera.Follow = playerInstance.transform;
    }
}