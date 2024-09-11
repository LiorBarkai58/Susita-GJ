using Characters.Player;
using UnityEngine;

public class FiberGlass : MonoBehaviour
{
    [SerializeField] private int points = 100;

    [SerializeField] private PlayerScore playerScore;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        Debug.Log("PointsCollected");
        playerScore.AddToScore(points);
        Destroy(gameObject);
    }
}
