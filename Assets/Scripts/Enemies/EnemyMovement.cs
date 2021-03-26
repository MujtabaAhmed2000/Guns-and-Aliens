using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.08f;
    // public float jumpForce = 7f;
    // public bool isInAir = false;
    Rigidbody2D rbody;
    Vector3 velocityV3;
    Vector3 scale;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        scale = transform.localScale;
    }

    void FixedUpdate(){
        move();
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
        if(facingRight)
            flipDirection();
    }
    void moveRight(){
        // Debug.Log("Moved Right");
        transform.position += new Vector3(speed, 0, 0);
        if(!facingRight)
            flipDirection();
    }
    // void jump(){
    //     // Debug.Log("Jumped");
    //     rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    // }

    void flipDirection(){
        // Debug.Log("flipped");
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Walls"){
            if(facingRight){
                flipDirection();
            }
            else{
                flipDirection();
            }
        }
    }
}
