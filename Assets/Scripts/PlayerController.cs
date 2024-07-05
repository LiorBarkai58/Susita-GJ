using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class PlayerController : MonoBehaviour
{
    Controls controls;
    InputAction move;
    InputAction jump;

    private bool isJumping = false;
    private float jumpDuration = 1f;
    private float jumpSpeed;
    private float jumpTimer = 0.0f;
    [SerializeField] private float jumpHeight = 2f;
    private Vector3 initialPosition;


    [SerializeField] float currentPos = 0;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] private float currency = 0;

    void Awake(){
        controls = new Controls();
        move = controls.Player.Move;
        jump = controls.Player.Jump;
    }
    void OnEnable(){
        controls.Enable();
        move.Enable();
        jump.Enable();
    }
    void OnDisable(){
        controls.Disable();
        move.Disable();
        jump.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        jumpSpeed = jumpHeight / jumpDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (jump.WasPressedThisFrame())
        {
            StartJump();
        }
        if (isJumping)
        {
            Jump();
        }
        if (move.WasPressedThisFrame()){
            currentPos = Math.Clamp(currentPos + move.ReadValue<float>(),-1, 1);
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, currentPos*4), Time.deltaTime*moveSpeed);//Should potentially be time.deltatime, currently 1 for testing
    }

    public void giveCurrency(float currency)
    {
        this.currency += currency;
    }

    private void StartJump()
    {
        if (!isJumping)
        {
            isJumping = true;
            jumpTimer = 0.0f;
        }
    }
    private void Jump()
    {
        
    }
}
