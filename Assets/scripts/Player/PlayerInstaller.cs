using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerUnit playerUnit;
    [SerializeField] private Transform playerSpawnPoint;
    public override void InstallBindings()
    {
        var playerInstance = Container.InstantiatePrefabForComponent<PlayerUnit>(playerUnit, playerSpawnPoint.position, Quaternion.identity, null);

        Container.Bind<PlayerUnit>().FromInstance(playerInstance).AsSingle().NonLazy();
    }
}