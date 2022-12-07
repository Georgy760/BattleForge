using System;
using UnityEngine;

namespace Common
{
    public interface IControllerService
    {
        event Action<Vector2> OnControllerHold;
        event Action<GameObject> OnAttackClicked;
    }
}
