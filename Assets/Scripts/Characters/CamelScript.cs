using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamelScript : MonoBehaviour
{
    [SerializeField] float currentPos = 0;
    [SerializeField] float moveSpeed = 12f;

    [SerializeField] float distance = 4f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPos*distance, transform.position.y, transform.position.z), Time.deltaTime*moveSpeed);//Should potentially be time.deltatime, currently 1 for testing
        
    }
    void getCloser(){
        currentPos += 1;
    }
}
