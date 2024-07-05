using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    private float speed = 12;
    [SerializeField] private float obstacleStrength;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed,0,0) * Time.deltaTime;

    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            if(obstacleStrength == 1){
                CamelScript.camelInstance.getCloser();
            }
            if(obstacleStrength == 2){
                CamelScript.camelInstance.moveToPlayer();
            }
        }
    }
}
