using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public Transform topLeftSpawner;
    public Transform topRightTransform;
    EnemyInfo info;
    EnemyMovement movement;

    void Awake(){
        GameObject left = GameObject.Find("SpawnerTopLeft");
        GameObject right = GameObject.Find("SpawnerTopRight");
        topLeftSpawner = left.GetComponent<Transform>();
        topRightTransform = right.GetComponent<Transform>();

        info = this.GetComponent<EnemyInfo>();
        movement = this.GetComponent<EnemyMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Despawner"){
            if(!info.carryingGold){
                movement.flipDirection();
            }
            else{
                transform.localPosition = topLeftSpawner.localPosition;
            }
        }
    }
}
