using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int score;
    public int goldCarry;
    public bool carryingGold = false;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        goldCarry = 0;
    }

    public void setCarryGoldTrue(){
        carryingGold = true;
        spriteRenderer.enabled = true;
    }

    public void setCarryGoldFalse(){
        carryingGold = false;
        spriteRenderer.enabled = false;
    }
}
