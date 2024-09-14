using System;
using Characters.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerScore playerScore;

    [SerializeField] private GameObject inGameUi;
    [SerializeField] private GameObject gameOverWinUi;

    [SerializeField] private GameObject gameOverLoseUi;

    [SerializeField] private Pause pause;

    [SerializeField] private int winingScore = 1000;

    private void Update()
    {
        CheckWin();
    }

    private void CheckWin()
    {
        if (playerScore.score < winingScore) return;
        
        TriggerWin();
    }

    public void TriggerWin(){
        inGameUi.SetActive(false);
        gameOverWinUi.SetActive(true);
        pause.PauseGame();
        PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().buildIndex}", 1);
    }
    public void TriggerLoss(){
        inGameUi.SetActive(false);
        gameOverLoseUi.SetActive(true);
        pause.PauseGame();
    }
    
}
