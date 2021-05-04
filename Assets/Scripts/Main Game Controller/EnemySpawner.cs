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
    public Transform midLeftSpawner;
    public Transform midRightSpawner;
    public float spawnTimer = 2f;
    public float spawnTimer2 = 5f;

    void FixedUpdate() 
    {
        spawnTimer -= Time.fixedDeltaTime;
        spawnTimer2 -= Time.fixedDeltaTime;

        if (spawnTimer <= 0.0f){
            spawnEnemy();
            resetSpawnTimer();
        }

        if (spawnTimer2 <= 0.0f){
            spawnEnemy();
            spawnEnemy2();
            resetSpawnTimer2();
        }
    }

    void spawnEnemy(){
        float rand = Random.Range(0f, 4f);
        float rand2 = Random.Range(0f, 1f);

        if(rand <= 1){
            if(rand2 <= 0.5){
                spawnSmallGrunt(topLeftSpawner);
            }
            else{
                spawnGhost(topLeftSpawner);
            }
        }
        else if(rand <= 2){
            if(rand2 <= 0.5){
                spawnSmallGrunt(topRightSpawner);
            }
            else{
                spawnGhost(topRightSpawner);
            }
        }
        else if(rand <= 3){
            if(rand2 <= 0.5){
                spawnSmallGrunt(midLeftSpawner);
            }
            else{
                spawnGhost(midLeftSpawner);
            }
        }
        else{
            if(rand2 <= 0.5){
                spawnSmallGrunt(midRightSpawner);
            }
            else{
                spawnGhost(midRightSpawner);
            }
        }
    }

    void spawnEnemy2(){
        float rand = Random.Range(0f, 4f);

        if(rand <= 1){
            spawnLargeGrunt(topLeftSpawner);
        }
        else if(rand <= 2){
            spawnLargeGrunt(topRightSpawner);
        }
        else if(rand <= 3){
            spawnLargeGrunt(midLeftSpawner);
        }
        else{
            spawnLargeGrunt(midRightSpawner);
        }
    }

    void spawnSmallGrunt(Transform spawner){
        Instantiate(smallGruntPrefab, spawner.position, spawner.rotation);
    }

    void spawnLargeGrunt(Transform spawner){
        Instantiate(largeGruntPrefab, spawner.position, spawner.rotation);
    }

    void spawnGhost(Transform spawner){
        Instantiate(ghostPrefab, spawner.position, spawner.rotation);
    }

    void resetSpawnTimer(){
        spawnTimer = 2f;
    }

    void resetSpawnTimer2(){
        spawnTimer2 = 5f;
    }
}
