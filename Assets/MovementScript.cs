using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 0.08f;
    public float jumpForce = 7f;
    public bool isInAir = false;
    float xAxisInput;
    Rigidbody2D rbody;
    Vector3 velocityV3;
    public bool facingRight = true;
    public bool facingLeft = false;
    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position += new Vector3(0, -0.8f, 0);
        transform.localScale.Set(2, 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        rbody = GetComponent<Rigidbody2D>();
        xAxisInput = Input.GetAxisRaw("Horizontal") * speed;
        velocityV3 = rbody.velocity;
    }

    void FixedUpdate(){
        if(velocityV3.y != 0){
            isInAir = true;
        }
        else{
            isInAir = false;
        }

        if(xAxisInput > 0){
            xAxisInput *= Time.fixedDeltaTime;
            moveRight();
        }
        if(xAxisInput < 0){
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
        facingLeft = true;
        facingRight = false;
        if(facingRight){
            flipDirection(true);
        }
    }
    void moveRight(){
        // Debug.Log("Moved Right");
        transform.position += new Vector3(speed, 0, 0);
        facingLeft = false;
        facingRight = true;
        if(facingLeft){
            flipDirection(false);
        }
    }
    void jump(){
        // Debug.Log("Jumped");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    //true means face left, false means face right
    void flipDirection(bool direction){
        localScale = transform.localScale;
        // Debug.Log(transform.localScale);
        if(direction){
            localScale.Set(0.2f, 0.2f, 1);
            transform.localScale = localScale;  
        }
        else{
            localScale.Set(-0.2f, 0.2f, 1);
            transform.localScale = localScale;
        }
        
    }
}
