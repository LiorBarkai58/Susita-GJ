using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    [SerializeField] private float roadLength;
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Floor")
        {
            Vector3 roadPos = collider.transform.parent.position + new Vector3(-roadLength, 0, 0);
            GameObject floor = ObjectPool.SharedInstance.GetPooledObject();
            if (floor != null)
            {
                floor.transform.position = roadPos;
                floor.SetActive(true);
            }
        }
    }
}
