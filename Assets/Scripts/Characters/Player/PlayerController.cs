using System;
using System.Collections;
using Environment;
using TMPro;
using Ui;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

namespace Characters.Player
{
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
            new Cooldown(MOVE_INPUT_COOLDOWN);
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

        void Update()
        {
            if(EnvironmentManager.gameOver) return;
            if (jump.WasPressedThisFrame() && IsGrounded())
            {
                Jump();
            }
            if (Skill.WasPressedThisFrame()){
                _skillManager.ActivateSkill();
            }

            if((FollowMove.WasPerformedThisFrame() || FollowMove.IsPressed())&& !HoverableUI.UIHovered){
                _targetPosition = GetHitFromClick();
            }
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,targetY > 0 ? targetY : transform.position.y, Math.Clamp(_targetPosition.z, -0.93f, 4.1f)), Time.deltaTime * moveSpeed);
            camel.moveHorizontal(transform.position.z);
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

        private bool IsGrounded() {
            RaycastHit hit;
            float rayLength = 1.1f; // Adjust based on your character's size
            return Physics.Raycast(transform.position, Vector3.down, out hit, rayLength);
        }
        
        private void Jump()
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
        
        public IEnumerator Flight(float duration, TextMeshProUGUI text){
            rb.isKinematic = true;
            targetY = 6.5f;
            text.SetText("Flight");
            yield return new WaitForSeconds(duration);
            text.SetText("");
            rb.isKinematic = false;
            targetY = 0;

        }
    }
}
