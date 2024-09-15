using System;
using System.Collections;
using TMPro;
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

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameOver gameoverScreen;

    [SerializeField] private float fallMultiplier = 2.5f;

    [SerializeField] private TextMeshProUGUI Timer;

    private float _countdown = 60f;




    private Vector3 _targetPosition;


    void Awake(){
        
        rb = GetComponent<Rigidbody>();
        _targetPosition = transform.position;

        

    }
    void OnEnable(){
        StartCoroutine(MoveBoss());
        _countdown = 60f;
        Time.timeScale = 1;
    }
    void OnDisable(){
        StopCoroutine(MoveBoss());
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if(EnvironmentManager.gameOver) return;
        if(_countdown <= 0){
            if(player.transform.position.x < transform.position.x){
                gameManager.TriggerWin();
            }
            else{
                gameManager.TriggerLoss();
            }
        }
        else{
            _countdown -= Time.deltaTime;
            Timer.SetText($"{(int)_countdown}");    
        }
        if(EnvironmentManager.IsSlowed){
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x-(Time.deltaTime*moveSpeed*6), transform.position.y, Math.Clamp(_targetPosition.z, -0.93f, 4.1f)), Time.deltaTime * moveSpeed);
        }
        else{
            float targetX = player.transform.position.x < transform.position.x ? player.transform.position.x + 2.5f : transform.position.x + (Time.deltaTime*moveSpeed*4);
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
