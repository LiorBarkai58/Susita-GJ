using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    //This script is attached to the floorgenerator prefab
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Floor")
        {
            Vector3 roadPos = collider.transform.parent.position + new Vector3(-Constants.roadLength, 0, 0);
            GameObject floor = ObjectPool.SharedInstance.GetPooledObject();
            if (floor != null)
            {
                floor.transform.position = roadPos;
                floor.SetActive(true);
            }
        }
    }
}
