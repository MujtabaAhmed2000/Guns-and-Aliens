using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    [SerializeField] List<GameObject> pooledObjects;
    // [SerializeField] GameObject objectToPool;
    // [SerializeField] int amountToPool;
    [SerializeField] List<ObjectPoolItem> itemsToPool;

    void Awake() {
        SharedInstance = this;
    }
    void Start()
    {
        // pooledObjects = new List<GameObject>();
        // for (int i = 0; i < amountToPool; i++) {
        //     GameObject obj = (GameObject)Instantiate(objectToPool);
        //     obj.SetActive(false); 
        //     pooledObjects.Add(obj);
        // }
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool) {
                for (int i = 0; i < item.amountToPool; i++) {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    void Update()
    {
        
    }

    // public GameObject GetPooledObject() {
    //     for (int i = 0; i < pooledObjects.Count; i++){
    //         if(!pooledObjects[i].activeInHierarchy){
    //             return pooledObjects[i];
    //         }
    //     }
    //     return null;
    // }

    public GameObject GetPooledObject(string tag) {
        for (int i = 0; i < pooledObjects.Count; i++) {
                if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool) {
            if (item.objectToPool.tag == tag) {
                if (item.shouldExpand) {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

}
