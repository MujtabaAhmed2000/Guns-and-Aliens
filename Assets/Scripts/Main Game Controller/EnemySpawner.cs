using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject smallGruntPrefab;
    public GameObject largeGruntPrefab;
    public GameObject ghostPrefab;
    public Transform topLeftSpawner;
    public Transform topRightSpawner;
    public float spawnTimer = 2f;

    void FixedUpdate() 
    {
        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer <= 0.0f){
            spawnEnemy();
            resetSpawnTimer();
        }
    }

    void spawnEnemy(){
        if(Random.Range(0f, 1f) < 0.5){
            Instantiate(smallGruntPrefab, topLeftSpawner.position, topLeftSpawner.rotation);
            Instantiate(largeGruntPrefab, topLeftSpawner.position, topLeftSpawner.rotation);
            Instantiate(ghostPrefab, topLeftSpawner.position, topLeftSpawner.rotation);
        }
        else{
            Instantiate(smallGruntPrefab, topRightSpawner.position, topRightSpawner.rotation);
            Instantiate(largeGruntPrefab, topLeftSpawner.position, topLeftSpawner.rotation);
            Instantiate(ghostPrefab, topRightSpawner.position, topLeftSpawner.rotation);
        }
    }

    void resetSpawnTimer(){
        spawnTimer = 2f;
    }

}
