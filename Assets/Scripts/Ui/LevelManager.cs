using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class LevelManager : MonoBehaviour
    {
        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
