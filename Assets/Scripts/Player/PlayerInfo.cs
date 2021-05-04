using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int score;
    public int goldCarry;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        goldCarry = 0;
    }
}
