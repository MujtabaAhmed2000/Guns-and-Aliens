using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
    public int value = 10;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            PlayerInfo info = collider.GetComponent<PlayerInfo>();
            if(info.addGold(value)){
                info.setCarryGoldTrue();
                Destroy(gameObject);
            }
        }
    }
}
