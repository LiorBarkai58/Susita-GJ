using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] EnvironmentManager EnvironmentManager;//Insert the environment manager to this



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            EnvironmentManager.reduceSpeed();
        }
    }
    
    
}
