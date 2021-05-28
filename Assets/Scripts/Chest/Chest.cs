using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public int gold = 10;
    public Text goldCount;

    void depositGold(int amount){
        gold += amount;
    }

    int stealGold(){
        if(gold >= 10){
            gold -= 10;
            return 10;
        }
        else{
            GameOver();
            return 0;
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
        GameOverPanel.SetActive(true);
        Time.timeScale = 0.5f;
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
            if(amount != 0)
                info.setCarryGoldTrue();
            info.goldCarry += amount;
        }
    }

    public int getGold(){
        return gold;
    }

    void Update()
    {
        goldUpdate();
    }
    
    void goldUpdate(){
        goldCount.text = "" + gold;
    }
}
