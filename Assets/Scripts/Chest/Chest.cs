using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int gold;

    void depositGold(int amount){
        gold += amount;
    }

    int stealGold(){
        if(gold >= 10){
            gold -= 10;
            return 10;
        }
        else{
            return 0;
        }

    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            PlayerInfo info = collision.gameObject.GetComponent<PlayerInfo>();
            depositGold(info.goldCarry);
            info.goldCarry = 0;
            info.setCarryGoldFalse();
        }
        if(collision.gameObject.tag == "Enemy"){
            int amount = stealGold();
            EnemyInfo info = collision.gameObject.GetComponent<EnemyInfo>();
            info.goldCarry += amount;
        }
    }
}
