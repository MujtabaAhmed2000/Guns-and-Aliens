using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGrunt : MonoBehaviour
{
    public int hp = 2;
    
    public void takeDamage(int damage){
        hp -= damage;

        if(hp <= 0){
            die();
        }
    }

    void die(){
        Destroy(gameObject);
    }
}
