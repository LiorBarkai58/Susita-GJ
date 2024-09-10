using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camera controller, uses player position to determine its position
    [SerializeField] private GameObject player;//Attach player prefab in scene to the camera

    [SerializeField] float Yoffset;
    private float zRatio = 0.65f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y + Yoffset, Mathf.Clamp(player.transform.position.z, 0.27f, 2.87f)), Time.deltaTime*4);
    }

    
}
