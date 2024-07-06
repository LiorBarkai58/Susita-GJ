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

    private Rigidbody rb;
    [SerializeField] float currentPos = 0;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] private float currency = 0;

    [SerializeField] private float jumpForce = 7.5f;

    [SerializeField] private GameOver gameoverScreen;
    
    [SerializeField] private float fallMultiplier = 2.5f;

    private float jumpFallMultiplier = 1.5f;

    [SerializeField] private CamelScript camel;

    void Awake(){
        rb = GetComponent<Rigidbody>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (jump.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }
        if(rb.velocity.y < 0){
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
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
    public bool IsGrounded() {
        RaycastHit hit;
        float rayLength = 1.1f; // Adjust based on your character's size
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength)) {
            return true;
        }
        return false;
}

    
    private void Jump()
    {
        rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Obstacle-S"){
            camel.getCloser();
        }
        if(collider.gameObject.tag == "Obstacle-B"){
            camel.moveToPlayer();
            Debug.Log("game over logic here");
            EnvironmentMovement.PlayerCaught();
            gameoverScreen.Setup(10);

        }
        
    }
    
}
