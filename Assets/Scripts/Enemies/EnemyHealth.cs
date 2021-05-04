using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 2;
    // GameObject player = get component of player 

    public void takeDamage(int damage){
        hp -= damage;

        if(hp <= 0){
            die();
        }
    }

    void die(){
        Destroy(gameObject);
        // increase score
    }
}
