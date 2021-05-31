using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject goldPrefab;
    
    public Transform[] GoldSpawnerPos;

    public float spawntimer = 4f;

    void FixedUpdate()
    {
        spawntimer -= Time.fixedDeltaTime;

        if (spawntimer <= 0.0f){
            spawnGold();
            resetSpawnTimer();
        }
        
    }

    void spawnGold()
    {
        int randomLocation = (int)Random.Range(0f, 18f);

        spawnToLocation(GoldSpawnerPos[randomLocation]);


    }

    void spawnToLocation(Transform spawner)
    {
        Instantiate(goldPrefab, spawner.position, spawner.rotation);
    }
    
    void resetSpawnTimer()
    {
        spawntimer = 4f;
    }
}
