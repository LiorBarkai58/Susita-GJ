using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    private float speed = 12;

    private static bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
            transform.position += new Vector3(speed,0,0) * Time.deltaTime;
        }
    }

    public static void PlayerCaught(){
        gameOver = true;
    }

}
