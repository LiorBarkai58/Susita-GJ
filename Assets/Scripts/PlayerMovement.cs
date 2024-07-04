using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class PlayerMovement : MonoBehaviour
{
    Controls controls;
    InputAction move;
    [SerializeField] float currentPos = 0;
    [SerializeField] float moveSpeed = 12f;

    void Awake(){
        controls = new Controls();
        move = controls.Player.Move;
    }
    void OnEnable(){
        controls.Enable();
        move.Enable();
    }
    void OnDisable(){
        controls.Disable();
        move.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(move.WasPressedThisFrame()){
            currentPos = Math.Clamp(currentPos + move.ReadValue<float>(),-1, 1);
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, currentPos*4), Time.deltaTime*moveSpeed);//Should potentially be time.deltatime, currently 1 for testing
    }
}
