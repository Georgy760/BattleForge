using UnityEngine;

namespace Legacy.scripts
{
    public class FlagPlacement : MonoBehaviour
    {
        [SerializeField] private Team.teamColor _teamColor;
        public Team team;

        private void Start()
        {
            team = new Team(_teamColor);
        }
    }
}
