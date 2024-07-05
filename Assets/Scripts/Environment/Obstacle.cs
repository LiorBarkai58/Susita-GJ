using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private CamelScript camelLogic;
    private float speed = 12;



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
            camelLogic.getCloser();
        }
    }
}
