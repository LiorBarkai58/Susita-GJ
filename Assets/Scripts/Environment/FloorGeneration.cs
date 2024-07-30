using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Floor")
        {
            Vector3 roadPos = collider.transform.parent.position + new Vector3(-Constants.roadLength, 0, 0);
            GameObject floor = ObjectPool.SharedInstance.GetPooledObject();
            Debug.Log(floor);
            if (floor != null)
            {
                floor.transform.position = roadPos;
                floor.SetActive(true);
            }
        }
    }
}
