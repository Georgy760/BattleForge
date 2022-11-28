using UnityEngine;

namespace Legacy.scripts.UI
{
    public class LookAtCam : MonoBehaviour
    {
        public Transform cam;

        private void Start()
        {
        
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
}
