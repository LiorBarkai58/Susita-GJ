using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject EnvironmentManager;
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<GameObject> objectsToPool;
    public int amountToPool;
    private int floorCounter = 0;

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
            tmp = Instantiate(objectsToPool[i], EnvironmentManager.transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Gets the next available pooled object
    public GameObject GetPooledObject()
    {
        if(pooledObjects.Count == 0){
            return null;
        }
        float softLimit = 20;
        float limitCounter = 0;
        int index = Random.Range(0, pooledObjects.Count);
        while (pooledObjects[floorCounter % pooledObjects.Count].activeInHierarchy && limitCounter < softLimit)
        {
            limitCounter++;
            floorCounter++;
        }
        return pooledObjects[floorCounter%pooledObjects.Count];
    }
}
