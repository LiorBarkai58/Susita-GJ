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
        Debug.Log("test");
        Instantiate(floors[Random.Range(0, floors.Count)], new Vector3(25, 0,0), Quaternion.identity);
    }
}
