using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    [SerializeField] List<GameObject> floors;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider){
        Debug.Log(collider.GetComponentInParent<Transform>().position);
        Vector3 roadPos = collider.transform.parent.position + new Vector3(-50, 0, 0);
        GameObject floor = ObjectPool.SharedInstance.GetPooledObject();
        if (floor != null)
        {
            floor.transform.position = roadPos;
            floor.SetActive(true);
        }
    }
}
