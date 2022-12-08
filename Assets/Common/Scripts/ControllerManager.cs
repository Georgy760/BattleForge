using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common
{
    public class ControllerManager : MonoBehaviour, IControllerService
    {
    
        public event Action<Vector2> OnControllerHold;
        public event Action<GameObject> OnAttackClicked;
        private PlayerInputActions _playerInputActions;
        
        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
            _playerInputActions.Player.Move.performed += MovePreformed;
        }

        private void FixedUpdate()
        {
            if (_playerInputActions.Player.Move.IsPressed())
            {
                OnControllerHold?.Invoke(_playerInputActions.Player.Move.ReadValue<Vector2>());
            }
        }

        private void MovePreformed(InputAction.CallbackContext context)
        {
            OnControllerHold?.Invoke(context.ReadValue<Vector2>());
        }
    }
}
