using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private bool start = false;
    [SerializeField] private float duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if(start){
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking(){
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration){
            Debug.Log("test");
            elapsedTime += Time.deltaTime;
            Vector3 randomPos = Random.insideUnitSphere;
            transform.position = startPosition + randomPos;
            yield return null;
        }
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
