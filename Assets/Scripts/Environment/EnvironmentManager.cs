using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private float speed = 25f;

    private static bool gameOver = false;

    private float reducedSpeed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
            transform.position += new Vector3(speed- reducedSpeed,0,0) * Time.deltaTime;
        }
    }

    public static void PlayerCaught(){
        gameOver = true;
    }
    public void reduceSpeed(){

    }
    IEnumerator slow(){
        reducedSpeed = 10;
        yield return new WaitForSeconds(6f);

        reducedSpeed = 0;
    }
}
