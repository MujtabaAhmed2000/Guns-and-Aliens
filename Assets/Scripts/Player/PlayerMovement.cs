using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.14f;
    [SerializeField] float jumpForce = 7f;
    bool isInAir = false;
    float xAxisInput;
    Rigidbody2D rbody;
    Vector3 velocityV3;
    Vector3 scale;
    bool facingRight = true;
    [SerializeField] Joystick joystick;
    [SerializeField] Animator animator;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // xAxisInput = Input.GetAxisRaw("Horizontal");
        xAxisInput = joystick.Horizontal;
        
        animator.SetFloat("Speed", Mathf.Abs(xAxisInput));
        velocityV3 = rbody.velocity;
        scale = transform.localScale;
    }

    void FixedUpdate(){
        if(velocityV3.y != 0){
            isInAir = true;
        }
        else{
            isInAir = false;
        }
        if(xAxisInput >= 0.2f){
            xAxisInput *= Time.fixedDeltaTime;
            moveRight();
        }
        if(xAxisInput <= -0.2f){
            xAxisInput *= Time.fixedDeltaTime;
            moveLeft();
        }
        if(Input.GetButton("Jump") && !isInAir){
            jump();
        }
    }

    void moveLeft(){
        // Debug.Log("Moved Left");
        transform.position += new Vector3(-speed, 0, 0);
        if(facingRight)
            flipDirection();
    }
    void moveRight(){
        // Debug.Log("Moved Right");
        transform.position += new Vector3(speed, 0, 0);
        if(!facingRight)
            flipDirection();
    }
    public void jump(){
        // Debug.Log("Jumped");
        rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void flipDirection(){
        // Debug.Log("flipped");
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
