using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class ObjectPool : MonoBehaviour
    {
        //Object pool with all the possible floors to generate.
        //This is using object pooling to improve performance
        [SerializeField] GameObject EnvironmentManager;//Environment manager prefab
        public static ObjectPool SharedInstance;
        public List<GameObject> pooledObjects;
        public List<GameObject> objectsToPool;//Add roads in inspector

        public GameObject finalObject;

        public bool PoolFinalObject = false;
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
            finalObject = Instantiate(finalObject, EnvironmentManager.transform);
            finalObject.SetActive(false);
            pooledObjects.Add(finalObject);
        }

        //Gets the next available pooled object
        public GameObject GetPooledObject()
        {
            if(pooledObjects.Count == 0 || PoolFinalObject){
                return finalObject;
            }
            float softLimit = 20;
            float limitCounter = 0;
            while (pooledObjects[floorCounter % pooledObjects.Count].activeInHierarchy && limitCounter < softLimit)
            {
                limitCounter++;
                floorCounter++;
            }
            return pooledObjects[floorCounter%pooledObjects.Count];
        }
    }
}
