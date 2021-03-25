using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptTest : MonoBehaviour
{
    public float speed = 0.08f;
    public float jumpForce = 0.5f;
    public float xAxisInput;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position += new Vector3(0, -0.8f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        xAxisInput = Input.GetAxisRaw("Horizontal") * speed;
    }

    void FixedUpdate(){
        if(xAxisInput > 0){
            xAxisInput *= Time.fixedDeltaTime;
            moveRight();
        }
        if(xAxisInput < 0){
            xAxisInput *= Time.fixedDeltaTime;
            moveLeft();
        }
        if(Input.GetButton("Jump")){
            jump();
        }
    }

    void moveLeft(){
        Debug.Log("Moved Left");
        transform.position += new Vector3(-speed, 0, 0);
    }
    void moveRight(){
        Debug.Log("Moved Right");
        transform.position += new Vector3(speed, 0, 0);
    }
    void jump(){
        Debug.Log("Jumped");
        // transform.position += new Vector3(0, jumpForce, 0);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
