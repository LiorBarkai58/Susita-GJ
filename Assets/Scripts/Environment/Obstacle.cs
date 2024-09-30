using UnityEngine;

namespace Environment
{
    public class Obstacle : MonoBehaviour
    {
        void OnTriggerEnter(Collider Collider)
        {
            if (!Collider.gameObject.CompareTag("Bullet")) return;
            
            Destroy(Collider.gameObject);
            Destroy(gameObject);
        }
    }
}
