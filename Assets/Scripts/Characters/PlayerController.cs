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
    [SerializeField] private Cooldown movementCD;
    private const float MOVE_INPUT_COOLDOWN = 0.15f;
    
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] private float currency = 0;

    [SerializeField] private float jumpForce = 7.5f;

    [SerializeField] private GameOver gameoverScreen;
    
    [SerializeField] private float fallMultiplier = 2.5f;


    [SerializeField] private CamelScript camel;
    [SerializeField] private CameraController cam;

    void Awake(){
        movementCD = new Cooldown(MOVE_INPUT_COOLDOWN);
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
        
        if (move.WasPressedThisFrame() && movementCD.IsReady()){
            float axisValue = Math.Sign(move.ReadValue<float>());
            
            currentPos = Math.Clamp(currentPos + axisValue,-1, 1);
            camel.moveHorizontal(currentPos);
            movementCD.startCooldown();
            
        }
        Move();
        
       
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


    private void Move(){
        
        float targetZ = Mathf.Lerp(transform.position.z, currentPos*4, Time.deltaTime*moveSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, targetZ);
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Obstacle-S"){
            camel.getCloser();
            if(camel.isOnPlayer()){
                endLogic(); 

            }
        }
        if(collider.gameObject.tag == "Obstacle-B"){
            camel.moveToPlayer();
            endLogic(); 
            

        }
        
    }

    void endLogic(){
            Debug.Log("game over logic here");
            EnvironmentMovement.PlayerCaught();
            gameoverScreen.Setup(10);
    }
    
}
