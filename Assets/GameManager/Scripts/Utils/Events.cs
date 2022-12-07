using UnityEngine.Events;

namespace GameManager.Scripts.Utils
{
    public class Events
    {
        [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { }
    }
}