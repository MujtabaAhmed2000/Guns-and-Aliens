using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGruntMovementScript : MonoBehaviour
{
    public float speed = 0.08f;
    Rigidbody2D rbody;
    SpriteRenderer spriteRenderer;
    Vector3 velocityV3;
    public bool facingRight = true;
    public bool facingLeft = false;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        velocityV3 = rbody.velocity;
    }

    void FixedUpdate(){
        // if(velocityV3.x == 0){
        //     if(facingRight){
        //         facingLeft = true;
        //         facingRight = false;
        //     }
        //     else if(facingLeft){
        //         facingRight = true;
        //         facingLeft = false;
        //     }
        // }
        // else{
        //     move();
        // }
        move();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Walls"){
            if(facingLeft){
                facingLeft = false;
                facingRight = true;
                flipDirection(false);
            }
            else if(facingRight){
                facingRight = false;
                facingLeft = true;
                flipDirection(true);
            }
        }
    }

    void move(){
        if(facingRight)
            moveRight();
        else
            moveLeft();
    }
    void moveLeft(){
        // Debug.Log("Moved Left");
        transform.position += new Vector3(-speed, 0, 0);
        facingLeft = true;
        facingRight = false;
    }
    void moveRight(){
        // Debug.Log("Moved Right");
        transform.position += new Vector3(speed, 0, 0);
        facingLeft = false;
        facingRight = true;
    }
    void flipDirection(bool direction){
        // Debug.Log("flipped");
        if(direction)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
}
