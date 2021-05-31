using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject smallGruntPrefab;
    [SerializeField] GameObject largeGruntPrefab;
    [SerializeField] GameObject ghostPrefab;
    [SerializeField] GameObject chaserPrefab;
    [SerializeField] Transform topLeftSpawner;
    [SerializeField] Transform topRightSpawner;
    [SerializeField] Transform midLeftSpawner;
    [SerializeField] Transform midRightSpawner;
    [SerializeField] float spawnTimer = 5f;
    [SerializeField] float spawnTimer2 = 10f;

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
        float rand2 = Random.Range(0f, 1f);

        if(rand <= 1){
            if(rand2 <= 0.5){
                spawnLargeGrunt(topLeftSpawner);
            }
            else{
                spawnChaser(topLeftSpawner);
            }
        }
        else if(rand <= 2){
            if(rand2 <= 0.5){
                spawnLargeGrunt(topRightSpawner);
            }
            else{
                spawnChaser(topRightSpawner);
            }
        }
        else if(rand <= 3){
            if(rand2 <= 0.5){
                spawnLargeGrunt(midLeftSpawner);
            }
            else{
                spawnChaser(midRightSpawner);
            }
        }
        else{
            if(rand2 <= 0.5){
                spawnLargeGrunt(midRightSpawner);
            }
            else{
                spawnChaser(midRightSpawner);
            }
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

    void spawnChaser(Transform spawner){
        Instantiate(chaserPrefab, spawner.position, spawner.rotation);
    }

    void resetSpawnTimer(){
        spawnTimer = 5f;
    }

    void resetSpawnTimer2(){
        spawnTimer2 = 10f;
    }
}
