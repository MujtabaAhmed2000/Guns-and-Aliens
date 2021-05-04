using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.08f;
    // public float jumpForce = 7f;
    // public bool isInAir = false;
    Rigidbody2D rbody;
    Vector3 scale;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //To make the sprite face left when spawns from tpo right corner
        if(transform.rotation.y == 0){
            facingRight = true;
        }
        else{
            facingRight = false;
        }
        Physics2D.IgnoreLayerCollision(6, 6);
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
        // if(facingRight)
        //     flipDirection();
        // facingRight = false;
    }
    void moveRight(){
        // Debug.Log("Moved Right");
        transform.position += new Vector3(speed, 0, 0);
        // if(!facingRight)
        //     flipDirection();
        // facingRight = true;
    }
    // void jump(){
    //     // Debug.Log("Jumped");
    //     rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    // }

    public void flipDirection(){
        // Debug.Log("flipped");
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Chest"){
            flipDirection();
        }
    }
}
