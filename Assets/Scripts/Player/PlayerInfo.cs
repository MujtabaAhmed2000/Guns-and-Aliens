using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int score;
    public int goldCarry;
    public int goldCarryLimit = 10;
    public bool carryingGold = false;
    public SpriteRenderer spriteRenderer;

    public Text scoreText;
    public Text lastScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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

    void Update()
    {
        scoreUpdate();
    }

    void scoreUpdate()
    {
        scoreText.text = score.ToString();
        lastScore = scoreText;
    }
}
