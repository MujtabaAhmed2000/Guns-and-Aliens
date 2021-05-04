using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{

    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchMove();
    }

    void TouchMove()
    {

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(mousePos.x > 1)
            {
                //move right
                transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
            }

            else if(mousePos.x < -1)
            {
                //move left
                transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
            }
        }

    }
}
