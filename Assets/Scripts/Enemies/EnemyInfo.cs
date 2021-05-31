using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public int goldCarry;
    public int goldCarryLimit = 10;
    public bool carryingGold = false;
    [SerializeField] SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        goldCarry = 0;
        carryingGold = false;
    }

    public bool addGold(int amount){
        if(goldCarry + amount > goldCarryLimit)
            return false;
        else{
            goldCarry += amount;
            return true;
        }
    }

    public void setCarryGoldTrue(){
        carryingGold = true;
        spriteRenderer.enabled = true;
    }

    public void setCarryGoldFalse(){
        carryingGold = false;
        spriteRenderer.enabled = false;
    }

    public void setGoldCarry(int amount){
        goldCarry = amount;
    }

    public int getGoldCarry(){
        return goldCarry;
    }

    public bool getCarryingGold(){
        return carryingGold;
    }
}
