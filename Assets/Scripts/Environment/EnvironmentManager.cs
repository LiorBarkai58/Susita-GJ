using System.Collections;
using UnityEngine;

namespace Environment
{
    public class EnvironmentManager : MonoBehaviour
    {
        //This script manages the movement of the environment, slowing it down, stopping it or speeding up.
        private float speed = 25f;

        public static bool gameOver = false;

        private float reducedSpeed = 0;

        private float currentSpeed = 0;
        private float _boostValue = 8f;

        public bool IsSlowed = false;
        
        void Start()
        {
            gameOver = false;
        }
        
        void Update()
        {
            float targetSpeed = speed - reducedSpeed;
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed,Time.deltaTime);
            if(!gameOver){
                transform.position += new Vector3(currentSpeed,0,0) * Time.deltaTime;
            }
        }

        public static void PlayerCaught(){
            gameOver = true;
        }
        public static void StopGame(){
            gameOver = true;
        }
        public void reduceSpeed(){
            StartCoroutine(slow());
        }

        public void InitiateSpeedBoost(){
            reducedSpeed = -_boostValue;
        }
        public void CancelSpeedBoost(){
            reducedSpeed = 0;
        }

        IEnumerator slow(){
            reducedSpeed = 10;
            IsSlowed = true;
            yield return new WaitForSeconds(6f);
            reducedSpeed = 0;
            IsSlowed = false;
        }
    }
}
