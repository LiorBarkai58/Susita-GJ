using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<GameObject> objectsToPool;
    public int amountToPool;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < objectsToPool.Count; i++)
        {
            tmp = Instantiate(objectsToPool[i]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        float softLimit = 20;
        float limitCounter = 0;
        int index = Random.Range(0, pooledObjects.Count);
        while (pooledObjects[index].activeInHierarchy && limitCounter < softLimit)
        {
            index = Random.Range(0, pooledObjects.Count);
            limitCounter++;
        }
        return pooledObjects[index];
    }
}
