using UnityEngine;

namespace Legacy.scripts.Player
{
    public class FlagTaker : MonoBehaviour
    {
        [SerializeField] private Transform takenFlag;
        [SerializeField] private Team.teamColor _teamColor;
        public Team team;

        //[SerializeField] private PlayerStats playerStats;
        private void Start()
        {
            team = new Team(_teamColor);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collision with: " + other.gameObject.name);
            if (other.gameObject.CompareTag("Flag") && !takenFlag && other.GetComponent<Flag>().team != team)
            {
                var flag = other.transform;
                flag.SetParent(transform, true);
                takenFlag = flag;
                takenFlag.localPosition = Vector3.zero;
                //takenFlag.position = new Vector3(0,0, -0.5f);
                Debug.Log("TakenFlag pos: " + takenFlag.position);
            }

            if (other.gameObject.CompareTag("FlagPlacement") && takenFlag && other.GetComponent<FlagPlacement>().team == team)
            {
                takenFlag.GetComponent<Flag>().ReturnFlag();
                takenFlag = null;
                Debug.Log("Flag returned");
            }
        }
    }
}
