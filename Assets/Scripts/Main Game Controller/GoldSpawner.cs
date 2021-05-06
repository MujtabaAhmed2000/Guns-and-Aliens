using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject goldPrefab;
    
    public Transform GoldSpawner1;
    public Transform GoldSpawner2;
    public Transform GoldSpawner3;
    public Transform GoldSpawner4;
    public Transform GoldSpawner5;
    public Transform GoldSpawner6;
    public Transform GoldSpawner7;
    public Transform GoldSpawner8;
    public Transform GoldSpawner9;
    public Transform GoldSpawner10;
    public Transform GoldSpawner11;
    public Transform GoldSpawner12;
    public Transform GoldSpawner13;
    public Transform GoldSpawner14;
    public Transform GoldSpawner15;
    public Transform GoldSpawner16;
    public Transform GoldSpawner17;
    public Transform GoldSpawner18;

    public float spawntimer = 2f;

    void FixedUpdate()
    {
        spawntimer -= Time.fixedDeltaTime;

        if (spawntimer <= 0.0f)
            spawnGold();
            //resetSpawnTimer();
        
    }

    void spawnGold()
    {
        int randomLocation = (int)Random.Range(0f, 18f);

        if (randomLocation == 1)
            spawnToLocation(GoldSpawner1);

        else if (randomLocation == 2)
            spawnToLocation(GoldSpawner2);

        else if (randomLocation == 3)
            spawnToLocation(GoldSpawner3);
        
        else if (randomLocation == 4)
            spawnToLocation(GoldSpawner4);

        else if (randomLocation == 5)
            spawnToLocation(GoldSpawner5);
        
        else if (randomLocation == 6)
            spawnToLocation(GoldSpawner6);
        
        else if (randomLocation == 7)
            spawnToLocation(GoldSpawner7);
        
        else if (randomLocation == 8)
            spawnToLocation(GoldSpawner8);
        
        else if (randomLocation == 9)
            spawnToLocation(GoldSpawner9);
        
        else if (randomLocation == 10)
            spawnToLocation(GoldSpawner10);
        
        else if (randomLocation == 11)
            spawnToLocation(GoldSpawner11);
        
        else if (randomLocation == 12)
            spawnToLocation(GoldSpawner12);
        
        else if (randomLocation == 13)
            spawnToLocation(GoldSpawner13);
        
        else if (randomLocation == 14)
            spawnToLocation(GoldSpawner14);
        
        else if (randomLocation == 15)
            spawnToLocation(GoldSpawner15);
        
        else if (randomLocation == 16)
            spawnToLocation(GoldSpawner16);
        
        else if (randomLocation == 17)
            spawnToLocation(GoldSpawner17);
        
        else if (randomLocation == 18)
            spawnToLocation(GoldSpawner18);


    }

    void spawnToLocation(Transform spawner)
    {
        Instantiate(goldPrefab, spawner.position, spawner.rotation);
    }
    
    void resetSpawnTimer()
    {
        spawntimer = 2f;
    }
}
