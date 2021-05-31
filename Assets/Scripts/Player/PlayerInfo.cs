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
    public Text currentScore;

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

    public void addScore(int amount){
        score += amount;
    }

    public void addGoldCarry(int amount){
        goldCarry += amount;
    }

    public void setGoldCarry(int amount){
        goldCarry = amount;
    }

    public int getGoldCarry(){
        return goldCarry;
    }

    void Update()
    {
        scoreUpdate();
    }

    void scoreUpdate()
    {
        string getText = scoreText.text;
        scoreText.text = score.ToString() ;
        currentScore.text = getText;
        lastScore.text = getText;
    }
}
