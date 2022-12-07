using GameManager.Scripts.Utils;
using UnityEngine;

namespace GameManager.Scripts.Menu
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private MainMenu _mainMenu;

        [SerializeField] private Camera _dummyCamera;

        public Events.EventFadeComplete OnMainMenuFadeComplete;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            _mainMenu.OnFadeComplete.AddListener(HandleMainMenuFadeComplete);
        }

        private void Update()
        {
            if (GameManager.Instance.CurrentGameState == GameManager.GameState.PREGAME)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.Instance.StartGame();
                }
            }
        }

        private void HandleMainMenuFadeComplete(bool fadeIn)
        {
            // pass it on
            OnMainMenuFadeComplete.Invoke(fadeIn);
        }

        public void SetDummyCameraActive(bool active)
        {
            _dummyCamera.gameObject.SetActive(active);
        }
    }
}