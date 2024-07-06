using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamelScript : MonoBehaviour
{
    
    private float currentPos = 2;

    private float horizontalPos = 0;
    [SerializeField] float moveSpeed = 12f;

    [SerializeField] private float distance = 3.5f;


    private float timerDuration = 6f;
    private bool isTimerActive = false;

    private float timer = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
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
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPos*distance, transform.position.y, horizontalPos*4), Time.deltaTime*moveSpeed);//Should potentially be time.deltatime, currently 1 for testing
        //Change camel horizontal distance to variable
    }
    public void getCloser(){
        currentPos = Math.Clamp(currentPos - 1, -1, 0);

    }
    public void moveAway(){
        currentPos = Math.Clamp(currentPos + 1, 0, 1);

    }
    public void moveToPlayer(){
        currentPos = 0;
    }

    public void moveHorizontal(float pos){
        horizontalPos = pos;
    }
    public bool isOnPlayer(){
        return currentPos == 0;
    }
    
}
