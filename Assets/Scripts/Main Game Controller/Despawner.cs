using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    EnemyInfo info;

    void Awake(){
        info = this.GetComponent<EnemyInfo>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Despawner"){
            if(!info.carryingGold){
                if(gameObject.name == "Small Grunt(Clone)" || gameObject.name == "Large Grunt(Clone)"){
                    EnemyMovement movement = this.GetComponent<EnemyMovement>();
                    movement.flipDirection();
                }
                else if(gameObject.name == "Ghost(Clone)"){
                    GhostMovement movement = this.GetComponent<GhostMovement>();
                    movement.flipXDirection();
                }
                else{
                    ChaserMovement movement = this.GetComponent<ChaserMovement>();
                    movement.flipDirection();
                }
            }
            else{
                Destroy(gameObject);
            }
        }
    }
}
