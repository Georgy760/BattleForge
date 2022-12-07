using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common
{
    public class ControllerManager : MonoBehaviour, IControllerService
    {
    
        public event Action<Vector2> OnControllerHold;
        public event Action<GameObject> OnAttackClicked;
    
        [SerializeField] private PlayerInput _playerInput;

        private void Awake()
        {
            if (!_playerInput)
            {
                _playerInput = GetComponent<PlayerInput>();
            }

            _playerInput.onActionTriggered += PlayerInput_onActionTriggered;
        }
    
        private void PlayerInput_onActionTriggered(InputAction.CallbackContext obj)
        {
            OnControllerHold?.Invoke(obj.ReadValue<Vector2>());
        }
    }
}
