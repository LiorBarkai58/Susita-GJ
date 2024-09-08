using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player
{
    public class PlayerScore : MonoBehaviour
    {
        private int _score;

        [SerializeField] private TextMeshProUGUI scoreText;

        void Update()
        {
            scoreText.text = _score.ToString();
        }

        public void AddToScore(int score)
        {
            _score += score;
        }
        
    }
}
