using System.Collections;
using System.Collections.Generic;
using Characters.Player;
using TMPro;
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

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private AudioManager audioManager;

    private float _powerupDuration = 6f;
    private bool _isProtected = false;
    
    //Will destroy and object with the tag "collectable"
    //Currency logic is yet to be implemented
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("FiberGlass")){
            score.AddToScore(1);
            StartCoroutine(HandleFiberGlass(collider.gameObject));
            audioManager.PlaySfx(audioManager.fiberglassCollected);
        }
        if(collider.gameObject.tag == "Collectable"){
            Debug.Log("Collected");
            Destroy(collider.gameObject, 0.1f);
            audioManager.PlaySfx(audioManager.powerUpCollected);
        }
        if(collider.gameObject.tag == "Obstacle-S"){
            if(_isProtected){
                StopCoroutine(ShieldPower());
                _isProtected = false; 
                return;
            }
            camel.getCloser();
            audioManager.PlaySfx(audioManager.bite);
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
            StartCoroutine(player.Flight(5, text));
        }
        if(collider.CompareTag("BoomBullet")){
            Destroy(collider.gameObject);
            Instantiate(bulletPrefab, transform.position + new Vector3(-5,0 ,0), Quaternion.identity);
            StartCoroutine(BoomText());
        }
        

        
        
    }
    void endLogic(){
        EnvironmentManager.PlayerCaught();
        audioManager.PlaySfx(audioManager.die);
        gameoverScreen.Setup(10);
    }
    IEnumerator ShieldPower(){
        _isProtected = true;
        text.SetText("Shielded");
        yield return new WaitForSeconds(_powerupDuration);
        text.SetText("");
        _isProtected = false;
    }
    IEnumerator SpeedBoost(){
        EnvironmentManager.InitiateSpeedBoost();
        text.SetText("Speed Boost");
        yield return new WaitForSeconds(_powerupDuration);
        text.SetText("");
        EnvironmentManager.CancelSpeedBoost();
    }
    IEnumerator BoomText(){
        text.SetText("Boom Bullet");
        yield return new WaitForSeconds(_powerupDuration);
        text.SetText("");
    }
    IEnumerator HandleFiberGlass(GameObject FiberGlass){
        FiberGlass.SetActive(false);
        yield return new WaitForSeconds(1);
        FiberGlass.SetActive(true);
    }
        
        
}
