using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camera controller, uses player position to determine its position
    [SerializeField] private GameObject player;//Attach player prefab in scene to the camera

    private float zRatio = 0.65f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(player.transform.position.z, 0.57f, 2.57f)), Time.deltaTime*4);
    }

    
}
