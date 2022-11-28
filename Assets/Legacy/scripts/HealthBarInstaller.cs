using Cinemachine;
using Legacy.scripts.healthsystem;
using UnityEngine;
using Zenject;

namespace Legacy.scripts
{
    public class HealthBarInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        [SerializeField] private HealthBar HealthBar;
        public override void InstallBindings()
        {
        
        }
    }
}