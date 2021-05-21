using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    ChaserMovement movement;
    [SerializeField] bool goldInSight = false;

    void Start()
    {
        movement = gameObject.GetComponent<ChaserMovement>();
    }

    void Update()
    {
        // Only find a new gold location when the currently pursued gold dissapears
        if(!goldInSight)
            getGoldLocation();
    }

    void FixedUpdate(){
        // if gold in sight, move towards the gold, otherwise follow normal path
        if(goldInSight){

        }
        else{
            movement.move();
        }
    }

    void getGoldLocation(){
        GameObject gold = GameObject.FindGameObjectWithTag("Gold");
        if(gold == null){
            goldInSight = false;
        }
        else{
            goldInSight = true;
        }
    }
}
