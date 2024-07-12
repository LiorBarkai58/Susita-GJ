using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This script will hold all the basic functions for the ui buttons that every scene will have
//Things like, Pause screen, back to menu, maybe some powerups.
public class ButtonBehavior : MonoBehaviour
{
    //Reloads current scene
    public void RetryCurrentLevel()
    {
        Debug.Log("Button clicked!");
        Scene currentScene = SceneManager.GetActiveScene();
        
        // Reload the current scene using its name
        SceneManager.LoadScene(currentScene.name);
        // Add your button click handling logic here
    }
}
