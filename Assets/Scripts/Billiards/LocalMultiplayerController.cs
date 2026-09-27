using UnityEngine;

namespace Billiards
{
    public class LocalMultiplayerController : MonoBehaviour
    {
        [Header("Input")]
        public KeyCode playerOneShoot = KeyCode.Space;
        public KeyCode playerTwoShoot = KeyCode.Return;

        private void Update()
        {
            if (GameManager.Instance == null)
            {
                return;
            }

            if (GameManager.Instance.currentMode != GameMode.LocalMultiplayer)
            {
                return;
            }

            if (GameManager.Instance.currentPlayer == 1 && Input.GetKeyDown(playerOneShoot))
            {
                // This can be connected to the actual cue shot logic when a local player shoots.
                Debug.Log("Player 1 shoots.");
            }

            if (GameManager.Instance.currentPlayer == 2 && Input.GetKeyDown(playerTwoShoot))
            {
                Debug.Log("Player 2 shoots.");
            }
        }
    }
}
