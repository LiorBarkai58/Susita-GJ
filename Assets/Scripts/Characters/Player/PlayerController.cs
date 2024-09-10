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
    InputAction FollowMove;
    InputAction TakeOff;


    InputAction Skill;
    private Rigidbody rb;
    [SerializeField] float currentPos = 0;
    [SerializeField] private Cooldown movementCD;
    private const float MOVE_INPUT_COOLDOWN = 0.15f;
    
    [SerializeField] EnvironmentManager EnvironmentManager;//Insert the environment manager to this

    [SerializeField] float moveSpeed = 12f;
    [SerializeField] private float currency = 0;

    [SerializeField] private float jumpForce = 7.5f;

    [SerializeField] private GameOver gameoverScreen;
    
    [SerializeField] private float fallMultiplier = 2.5f;


    [SerializeField] private CamelScript camel;
    [SerializeField] private CameraController cam;

    [SerializeField] private LayerMask TouchLayer;

    private SkillManager _skillManager;

    private Vector3 _targetPosition;

    private float targetY;

    void Awake(){
        movementCD = new Cooldown(MOVE_INPUT_COOLDOWN);
        rb = GetComponent<Rigidbody>();
        controls = new Controls();
        move = controls.Player.Move;
        jump = controls.Player.Jump;
        FollowMove = controls.Player.FollowMove;
        Skill = controls.Player.Skill;
        TakeOff = controls.Player.TakeOff;
        _targetPosition = transform.position;

        

    }
    void OnEnable(){
        controls.Enable();
        move.Enable();
        jump.Enable();
        FollowMove.Enable();
        Skill.Enable();
        TakeOff.Enable();
    }

    void OnDisable(){
        controls.Disable();
        move.Disable();
        jump.Disable();
        FollowMove.Disable();
        Skill.Disable();
        TakeOff.Disable();

    }
    

    // Update is called once per frame
    void Update()
    {
        if (jump.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }
        if (Skill.WasPressedThisFrame()){
            _skillManager.ActivateSkill();
        }
        
        
        
        // if (move.WasPressedThisFrame() && movementCD.IsReady()){
        //     float axisValue = Math.Sign(move.ReadValue<float>());
            
        //     currentPos = Math.Clamp(currentPos + axisValue,-1, 1);
        //     camel.moveHorizontal(currentPos);
        //     movementCD.startCooldown();
            
        // }
        if(FollowMove.WasPerformedThisFrame() && !HoverableUI.UIHovered){
            _targetPosition = GetHitFromClick();
            
            
        }
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,targetY > 0 ? targetY : transform.position.y, Math.Clamp(_targetPosition.z, -4, 4)), Time.deltaTime* moveSpeed);
        camel.moveHorizontal(transform.position.z);
        // Move();
        
       
    }
    private Vector3 GetHitFromClick(){
        Vector2 _inputVector = FollowMove.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(_inputVector);
        RaycastHit hit;

        // Check if the ray hits an object in the scene
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, TouchLayer))
        {   
            Debug.DrawRay(ray.origin, ray.direction*10f, Color.red);
            // Move the object to the hit point
        }
        if(hit.point == new Vector3(0,0,0)){
            return _targetPosition;
        }
        
        return hit.point;
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
    public IEnumerator Flight(float duration){
        rb.isKinematic = true;
        targetY = 6.5f;
        yield return new WaitForSeconds(duration);
        rb.isKinematic = false;
        targetY = 0;

    }

    
    

    
    
}
