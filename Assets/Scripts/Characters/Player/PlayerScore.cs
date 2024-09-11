using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Characters.Player
{
    public class PlayerScore : MonoBehaviour
    {
        [FormerlySerializedAs("_score")] public int score;

        [SerializeField] private TextMeshProUGUI scoreText;

        void Update()
        {
            scoreText.text = score.ToString();
        }

        public void AddToScore(int score)
        {
            this.score += score;
        }
        
    }
}
