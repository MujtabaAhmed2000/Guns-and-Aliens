using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    ChaserMovement movement;

    void Start()
    {
        movement = gameObject.GetComponent<ChaserMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
