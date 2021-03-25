using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 0.08f;
    public float horizontalMove;
    public float jumpForce = 0.5f;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
    }

    void FixedUpdate(){
        // controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
