using Characters.Player;
using Environment;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerScore playerScore;

    [SerializeField] private GameObject inGameUi;
    [SerializeField] private GameObject gameOverWinUi;

    [SerializeField] private GameObject gameOverLoseUi;

    [SerializeField] private Pause pause;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private int winingScore = 1000;

    void OnEnable(){
        Time.timeScale = 1;
        playerScore.UpdateMax(winingScore);
    }

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
        audioManager.DisableSfx();
        inGameUi.SetActive(false);
        gameOverWinUi.SetActive(true);
        EnvironmentManager.gameOver = true;
        PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().buildIndex}", 1);
    }
    public void TriggerLoss(){
        inGameUi.SetActive(false);
        gameOverLoseUi.SetActive(true);
        EnvironmentManager.gameOver = true;
    }
    
}
