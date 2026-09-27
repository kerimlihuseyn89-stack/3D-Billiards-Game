using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{
    public class GameHUDController : MonoBehaviour
    {
        [Header("HUD")]
        public Text turnText;
        public Text scoreText;
        public Text modeText;

        public void UpdateHUD(int currentPlayer, GameMode mode, int score1, int score2)
        {
            if (turnText != null)
            {
                turnText.text = "Player " + currentPlayer + " Turn";
            }

            if (modeText != null)
            {
                modeText.text = mode.ToString();
            }

            if (scoreText != null)
            {
                scoreText.text = "P1: " + score1 + "   |   P2: " + score2;
            }
        }
    }
}
