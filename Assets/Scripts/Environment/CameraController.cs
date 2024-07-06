using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float position = 0;
    private float cameraSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, position*3), Time.deltaTime*cameraSpeed);
    }

    public void moveLeft(){
        position = Math.Clamp(position - 1, -1, 0);

    }
    public void moveRight(){
        position = Math.Clamp(position + 1, 0, 1);
    }
}
