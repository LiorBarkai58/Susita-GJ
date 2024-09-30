using Environment;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    [SerializeField] private float roadLength;
    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Floor")) return;
        
        Vector3 roadPos = collider.transform.parent.position + new Vector3(-roadLength, 0, 0);
        GameObject floor = ObjectPool.SharedInstance.GetPooledObject();

        if (floor == null) return;
        
        floor.transform.position = roadPos;
        floor.SetActive(true);
    }
}
