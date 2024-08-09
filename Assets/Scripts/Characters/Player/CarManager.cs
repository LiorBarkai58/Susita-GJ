

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CarManager : MonoBehaviour{
    [SerializeField] private List<Rigidbody> carParts;


    public void OnPartDestroy(InputAction.CallbackContext context){
        if(context.started && carParts.Count > 0){
            Rigidbody current = carParts[Random.Range(0, carParts.Count)];
            current.isKinematic = false;
            current.linearVelocity = new Vector3(20,12,0);
            current.angularVelocity = new Vector3(7,0,0);
            carParts.Remove(current);
        }
    }

}