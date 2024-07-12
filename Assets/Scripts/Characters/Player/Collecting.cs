using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    //Will destroy and object with the tag "collectable"
    //Currency logic is yet to be implemented
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Collectable"){
            Debug.Log("Collected");
            Destroy(collider.gameObject, 0.1f);
        }
        
    }
}
