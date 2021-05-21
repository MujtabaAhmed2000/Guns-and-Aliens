using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public bool facingRight;
    public bool facingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        // assign random x and y speed to make ghost paths randomized
        assignNewSpeed();

        //To make the sprite face left when spawns from tpo right corner
        if(transform.rotation.y == 0){
            facingRight = true;
        }
        else{
            facingRight = false;
        }

        // Ignore the floors and other enemy grunts
        Physics2D.IgnoreLayerCollision(6, 6);
        Physics2D.IgnoreLayerCollision(8, 7);
        Physics2D.IgnoreLayerCollision(6, 8);
    }

    void FixedUpdate(){
        move();
    }

    void move(){
        if(facingRight)
            moveRight();
        else
            moveLeft();
        
        if(facingUp)
            moveUp();
        else
            moveDown();
    }

    void moveLeft(){
        transform.position += new Vector3(-xSpeed, 0, 0);
    }
    void moveRight(){
        transform.position += new Vector3(xSpeed, 0, 0);
    }
    void moveUp(){
        transform.position += new Vector3(0, ySpeed, 0);
    }
    void moveDown(){
        transform.position += new Vector3(0, -ySpeed, 0);
    }

    public void flipXDirection(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void flipYDirection(){
        facingUp = !facingUp;
    }

    void OnCollisionEnter2D(Collision2D collision){
        assignNewSpeed();
        if(collision.gameObject.tag == "GhostWalls"){
            flipXDirection();
        }
        if(collision.gameObject.tag == "GhostFloor"){
            flipYDirection();
        }
    }

    void assignNewSpeed(){
        xSpeed = Random.Range(0.02f, 0.06f);
        ySpeed = Random.Range(0.02f, 0.06f);
    }
}
