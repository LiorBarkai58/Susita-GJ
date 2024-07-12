using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Collectable"){
            Debug.Log("Collected");
            Destroy(collider.gameObject, 0.1f);
        }
        
    }
}
