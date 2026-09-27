using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Score Values")]
        public int playerOneScore = 0;
        public int playerTwoScore = 0;
        public int foulsPlayerOne = 0;
        public int foulsPlayerTwo = 0;

        public void ResetScores()
        {
            playerOneScore = 0;
            playerTwoScore = 0;
            foulsPlayerOne = 0;
            foulsPlayerTwo = 0;
        }

        public void AddScore(int playerNumber, int points)
        {
            if (playerNumber == 1)
            {
                playerOneScore += points;
            }
            else if (playerNumber == 2)
            {
                playerTwoScore += points;
            }
        }

        public void AddFoul(int playerNumber)
        {
            if (playerNumber == 1)
            {
                foulsPlayerOne++;
            }
            else if (playerNumber == 2)
            {
                foulsPlayerTwo++;
            }
        }

        public int GetScore(int playerNumber)
        {
            return playerNumber == 1 ? playerOneScore : playerTwoScore;
        }
    }
}
