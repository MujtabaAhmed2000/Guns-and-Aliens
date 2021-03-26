using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7f;
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Walls"){
            Destroy(gameObject);
        }
    }
}
