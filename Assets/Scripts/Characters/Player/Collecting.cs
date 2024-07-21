using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    enum Powerups {Shielded, Speeded}
    [SerializeField] EnvironmentManager EnvironmentManager;//Insert the environment manager to this
    [SerializeField] private CamelScript camel;
    
    [SerializeField] private GameOver gameoverScreen;

    private float _powerupDuration = 6f;
    private bool _isProtected = false;
    private bool _speedBoost = false;
    
    //Will destroy and object with the tag "collectable"
    //Currency logic is yet to be implemented
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Collectable"){
            Debug.Log("Collected");
            Destroy(collider.gameObject, 0.1f);
        }
        if(collider.gameObject.tag == "Obstacle-S"){
            if(_isProtected){
                StopCoroutine(ShieldPower());
                _isProtected = false; 
                return;
            }
            camel.getCloser();
            EnvironmentManager.reduceSpeed();
            if(camel.isOnPlayer()){
                endLogic(); 

            }
            
        }
        if(collider.gameObject.tag == "Obstacle-B"){
            if(_isProtected){ 
                StopCoroutine(ShieldPower());
                _isProtected = false;
                return;
            }

            camel.moveToPlayer();
            endLogic(); 
            
        }
        if(collider.CompareTag("ShieldP")){
            Destroy(collider.gameObject);
            StartCoroutine(ShieldPower());
        }
        if(collider.CompareTag("SpeedBoost")){
            Destroy(collider.gameObject);
            StartCoroutine(SpeedBoost());
        }

        
        
    }
    void endLogic(){
        Debug.Log("game over logic here");
        EnvironmentManager.PlayerCaught();
        gameoverScreen.Setup(10);
    }
    IEnumerator ShieldPower(){
        _isProtected = true;
        yield return new WaitForSeconds(_powerupDuration);
        _isProtected = false;
    }
    IEnumerator SpeedBoost(){
        EnvironmentManager.InitiateSpeedBoost();
        yield return new WaitForSeconds(_powerupDuration);
        EnvironmentManager.CancelSpeedBoost();
    }
        
        
}
