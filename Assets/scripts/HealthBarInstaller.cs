using Cinemachine;
using healthsystem;
using UnityEngine;
using Zenject;

public class HealthBarInstaller : MonoInstaller
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private HealthBar HealthBar;
    public override void InstallBindings()
    {
        
    }
}