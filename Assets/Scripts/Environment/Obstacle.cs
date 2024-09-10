using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void OnTriggerEnter(Collider Collider){
        if(Collider.gameObject.CompareTag("Bullet")){
            Destroy(Collider.gameObject);
            Destroy(gameObject);
        }

    }

    
    
    
    
}
