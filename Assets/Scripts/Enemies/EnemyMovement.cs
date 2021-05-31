using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.14f;
    bool facingRight;
    [SerializeField] Animator animator;
    

    void OnEnable()
    {
        //To make the sprite face left when spawns from tpo right corner
        if(transform.rotation.y == 0){
            facingRight = true;
        }
        else{
            facingRight = false;
        }
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    void FixedUpdate(){
        move();
        animator.SetFloat("Speed", speed);
    }

    void move(){
        if(facingRight)
            moveRight();
        else
            moveLeft();
    }

    void moveLeft(){
        transform.position += new Vector3(-speed, 0, 0);
    }
    void moveRight(){
        transform.position += new Vector3(speed, 0, 0);
    }

    public void flipDirection(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Chest"){
            flipDirection();
        }
    }
}
