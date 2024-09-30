using UnityEngine;

namespace Environment
{
    public class FloorDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (!collider.gameObject.CompareTag("Floor")) return;
            
            collider.transform.parent.gameObject.SetActive(false);
        }
    }
}
