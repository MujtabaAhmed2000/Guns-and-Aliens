using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int goldCarry;
    [SerializeField] int goldCarryLimit = 10;
    [SerializeField] bool carryingGold = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Text scoreText;
    //[SerializeField] Text lastScore;
    [SerializeField] Text currentScore;

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

    public void setGoldCarry(int amount){
        goldCarry = amount;
    }

    public int getGoldCarry(){
        return goldCarry;
    }

    public int getScore()
    {
        return score;
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
      //  lastScore.text = getText;
    }
}
