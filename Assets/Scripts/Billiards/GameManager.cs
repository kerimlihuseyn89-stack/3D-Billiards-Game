using System;
using UnityEngine;

namespace Billiards
{
    public enum GameMode
    {
        SinglePlayer,
        LocalMultiplayer,
        VsAI
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Game Setup")]
        public GameMode currentMode = GameMode.SinglePlayer;
        public int currentPlayer = 1;
        public bool isTurnActive = true;
        public bool isAITurn = false;

        [Header("References")]
        public BallController whiteBall;
        public BallController[] allBalls;
        public CueController cueController;
        public AIPlayerController aiController;
        public ScoreManager scoreManager;
        public GameHUDController hudController;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (hudController != null)
            {
                hudController.UpdateHUD(currentPlayer, currentMode, scoreManager.GetScore(1), scoreManager.GetScore(2));
            }
        }

        public void StartGame(GameMode mode)
        {
            currentMode = mode;
            currentPlayer = 1;
            isTurnActive = true;
            isAITurn = false;

            ResetRack();

            if (scoreManager != null)
            {
                scoreManager.ResetScores();
            }

            if (hudController != null)
            {
                hudController.UpdateHUD(currentPlayer, currentMode, scoreManager.GetScore(1), scoreManager.GetScore(2));
            }

            if (mode == GameMode.VsAI && currentPlayer == 2)
            {
                StartAISequence();
            }
        }

        public void ResetRack()
        {
            if (allBalls != null)
            {
                foreach (var ball in allBalls)
                {
                    if (ball != null)
                    {
                        ball.ResetBall();
                    }
                }
            }

            if (whiteBall != null)
            {
                whiteBall.ResetBall();
            }
        }

        public void OnBallPocketed(BallController pocketedBall)
        {
            if (scoreManager == null)
            {
                return;
            }

            if (pocketedBall == whiteBall)
            {
                scoreManager.AddFoul(currentPlayer);
                SwitchTurn();
                return;
            }

            scoreManager.AddScore(currentPlayer, 1);

            if (hudController != null)
            {
                hudController.UpdateHUD(currentPlayer, currentMode, scoreManager.GetScore(1), scoreManager.GetScore(2));
            }
        }

        public void OnShotCompleted()
        {
            if (AllBallsStopped())
            {
                SwitchTurn();
            }
        }

        public void SwitchTurn()
        {
            if (!isTurnActive)
            {
                return;
            }

            currentPlayer = currentPlayer == 1 ? 2 : 1;
            isAITurn = currentMode == GameMode.VsAI && currentPlayer == 2;

            if (hudController != null)
            {
                hudController.UpdateHUD(currentPlayer, currentMode, scoreManager.GetScore(1), scoreManager.GetScore(2));
            }

            if (isAITurn && aiController != null)
            {
                StartAISequence();
            }
        }

        public void StartAISequence()
        {
            if (aiController != null)
            {
                aiController.ExecuteTurn();
            }
        }

        public bool AllBallsStopped()
        {
            if (allBalls == null)
            {
                return true;
            }

            foreach (var ball in allBalls)
            {
                if (ball != null && ball.IsMoving())
                {
                    return false;
                }
            }

            if (whiteBall != null && whiteBall.IsMoving())
            {
                return false;
            }

            return true;
        }
    }
}
