using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public Transform topLeftSpawner;
    public Transform topRightTransform;

    void Awake(){
        GameObject left = GameObject.Find("SpawnerTopLeft");
        GameObject right = GameObject.Find("SpawnerTopRight");
        topLeftSpawner = left.GetComponent<Transform>();
        topRightTransform = right.GetComponent<Transform>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Despawner"){
            // Debug.Log("HIT");
            transform.localPosition = topLeftSpawner.localPosition;
            // EnemyMovement movement = GetComponent<EnemyMovement>();
            // movement.speed += 0.01f;
        }
    }
}
