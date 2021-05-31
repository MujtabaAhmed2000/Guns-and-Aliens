using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject player;

    void OnEnable(){
        player = GameObject.Find("Main Player");
        hp = 2;
    }

    public void takeDamage(int damage){
        hp -= damage;

        if(hp <= 0){
            die();
        }
    }

    public void die(){
        // Destroy(gameObject);
        gameObject.SetActive(false);
        PlayerInfo info = player.GetComponent<PlayerInfo>();
        info.addScore(1);
    }
}
