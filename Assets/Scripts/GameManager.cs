using System;
using Characters.Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerScore playerScore;

    [SerializeField] private GameObject inGameUi;
    [SerializeField] private GameObject gameOverWinUi;

    [SerializeField] private Pause pause;

    [SerializeField] private int winingScore = 1000;

    private void Update()
    {
        CheckWin();
    }

    private void CheckWin()
    {
        if (playerScore.score != winingScore) return;
        
        inGameUi.SetActive(false);
        gameOverWinUi.SetActive(true);
        pause.PauseGame();
    }
    
}
