using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Pause pause;
    
    public void Setup(float meters){
        gameObject.SetActive(true);
        pause.PauseGame();
    }
}
