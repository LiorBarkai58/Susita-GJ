using Characters.Player;
using UnityEngine;

public class FiberGlass : MonoBehaviour
{
    [SerializeField] private int points = 100;

    [SerializeField] private PlayerScore playerScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PointsCollected");
            playerScore.AddToScore(points);
            Destroy(gameObject, 0.1f);
        }
    }
}
