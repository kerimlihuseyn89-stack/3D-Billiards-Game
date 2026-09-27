using UnityEngine;
using UnityEngine.SceneManagement;

namespace Billiards
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartSinglePlayerMode()
        {
            StartGame(GameMode.SinglePlayer);
        }

        public void StartLocalMultiplayerMode()
        {
            StartGame(GameMode.LocalMultiplayer);
        }

        public void StartVsAIMode()
        {
            StartGame(GameMode.VsAI);
        }

        private void StartGame(GameMode mode)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.StartGame(mode);
            }
            else
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
