using UnityEngine;

namespace Legacy.scripts
{
    public class PlayersManager : MonoBehaviour
    {
        public static PlayersManager playersManager;

        private void Awake()
        {
            if (playersManager == null)
            {
                playersManager = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
    }
}
