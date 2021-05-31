using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hp = 2;
    [SerializeField] GameObject player;

    void Start(){
        player = GameObject.Find("Main Player");
    }

    public void takeDamage(int damage){
        hp -= damage;

        if(hp <= 0){
            die();
        }
    }

    public void die(){
        Destroy(gameObject);
        PlayerInfo info = player.GetComponent<PlayerInfo>();
        info.score += 1;
    }
}
