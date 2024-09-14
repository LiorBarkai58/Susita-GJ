using System.Collections;
using System.Collections.Generic;
using Characters.Player;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    enum Powerups {Shielded, Speeded}
    [SerializeField] EnvironmentManager EnvironmentManager;//Insert the environment manager to this

    [SerializeField] CarManager carManager;
    [SerializeField] private CamelScript camel;
    
    [SerializeField] private GameOver gameoverScreen;

    [SerializeField] private PlayerController player;

    [SerializeField] private PlayerScore score;

    [SerializeField] private GameObject bulletPrefab;

    private float _powerupDuration = 6f;
    private bool _isProtected = false;
    
    //Will destroy and object with the tag "collectable"
    //Currency logic is yet to be implemented
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("FiberGlass")){
            score.AddToScore(1);
            StartCoroutine(HandleFiberGlass(collider.gameObject));

        }
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
            carManager.OnPartDestroy();
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
        if(collider.CompareTag("Flight")){
            Destroy(collider.gameObject);
            StartCoroutine(player.Flight(10));
        }
        if(collider.CompareTag("BoomBullet")){
            Destroy(collider.gameObject);
            Instantiate(bulletPrefab, transform.position + new Vector3(-5,1 ,0), Quaternion.identity);
        }
        

        
        
    }
    void endLogic(){
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
    IEnumerator HandleFiberGlass(GameObject FiberGlass){
        FiberGlass.SetActive(false);
        yield return new WaitForSeconds(1);
        FiberGlass.SetActive(true);
    }
        
        
}
