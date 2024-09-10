using UnityEngine;

public class BoomBullet : MonoBehaviour
{

    void Update(){
        transform.position += new Vector3(-Time.deltaTime*12, 0, 0);
    }
    
}
