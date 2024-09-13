using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;


public class BossController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float currentPos = 0;
    [SerializeField] private Cooldown movementCD;
    
    [SerializeField] EnvironmentManager EnvironmentManager;//Insert the environment manager to this

    [SerializeField] PlayerController player;

    [SerializeField] float moveSpeed = 12f;

    [SerializeField] private float jumpForce = 7.5f;

    
    [SerializeField] private float fallMultiplier = 2.5f;




    private Vector3 _targetPosition;


    void Awake(){
        
        rb = GetComponent<Rigidbody>();
        _targetPosition = transform.position;

        

    }
    void OnEnable(){
        StartCoroutine(MoveBoss());
    }
    void OnDisable(){
        StopCoroutine(MoveBoss());
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
        if(EnvironmentManager.IsSlowed){
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x-(Time.deltaTime*moveSpeed*4   ), transform.position.y, Math.Clamp(_targetPosition.z, -0.93f, 4.1f)), Time.deltaTime * moveSpeed);
        }
        else{
            float targetX = player.transform.position.x < transform.position.x ? transform.position.x : transform.position.x + (Time.deltaTime*moveSpeed*4);
            transform.position = Vector3.Lerp(transform.position,new Vector3(targetX, transform.position.y, Math.Clamp(_targetPosition.z, -0.93f, 4.1f)), Time.deltaTime * moveSpeed);
        }
        
       
    }

    
    


    

    private IEnumerator MoveBoss(){
        while(true){
            _targetPosition = new Vector3(transform.position.x, transform.position.y, UnityEngine.Random.Range(-0.93f, 4.1f));
            yield return new WaitForSeconds(2);
        }
        
    }
    

    
    

    
    
}
