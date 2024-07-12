using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryCurrentLevel()
    {
        Debug.Log("Button clicked!");
        Scene currentScene = SceneManager.GetActiveScene();
        
        // Reload the current scene using its name
        SceneManager.LoadScene(currentScene.name);
        // Add your button click handling logic here
    }
}
