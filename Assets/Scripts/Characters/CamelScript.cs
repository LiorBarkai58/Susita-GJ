using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamelScript : MonoBehaviour
{
    public static CamelScript camelInstance;
    private static float currentPos = 2;
    [SerializeField] float moveSpeed = 12f;

    [SerializeField] private float distance = 4f;


    private float timerDuration = 6f;
    private bool isTimerActive = false;

    private float timer = 0f;



    // Start is called before the first frame update
    void Start()
    {
        if(camelInstance != null && camelInstance != this){
            Destroy(camelInstance);
        }
        else{
            camelInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPos == 1 ){
            if(!isTimerActive){
                isTimerActive = true;
                timer += Time.deltaTime;
            }
            else{
                timer+=Time.deltaTime;
            }
            if(timer > timerDuration){
                moveAway();
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPos*distance, transform.position.y, transform.position.z), Time.deltaTime*moveSpeed);//Should potentially be time.deltatime, currently 1 for testing
        
    }
    public void getCloser(){
        currentPos -= 1;
    }
    public void moveAway(){
        currentPos += 1;
    }
    public void moveToPlayer(){
        currentPos = 0;
    }
    
}
