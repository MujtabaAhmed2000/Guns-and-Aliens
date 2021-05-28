using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public int goldCarry;
    public int goldCarryLimit = 10;
    public bool carryingGold = false;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        goldCarry = 0;
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

    public bool getCarryingGold(){
        return carryingGold;
    }
}
