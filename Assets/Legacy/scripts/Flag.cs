using UnityEngine;

namespace Legacy.scripts
{
    public class Flag : MonoBehaviour
    {
        [SerializeField] private Transform FlagBase;
        [SerializeField] private Team.teamColor _teamColor;
        public Team team;
        private void Start()
        {
            team = new Team(_teamColor);
        }

        public void ReturnFlag()
        {
            transform.SetParent(FlagBase, true);
            transform.localPosition = Vector3.zero;
        }
    
    
    }
}
